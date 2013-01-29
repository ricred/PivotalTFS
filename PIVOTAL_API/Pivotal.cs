using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using PivotalTFS_GENERAL;

namespace PIVOTAL_API
{
	public class Pivotal : IPivotal
	{
		#region IterationVersion enum

		public enum IterationVersion
		{
			Done = 0,
			Current = 1,
			Backlog = 2,
			All = 3
		}

		#endregion

		private const string BaseURL = "https://www.pivotaltracker.com/services/v3/projects/";
		private const string TokenURL = "https://www.pivotaltracker.com/services/v3/tokens/active";
		private static IDictionary<string, XmlSerializer> xmlserializers;
		private string token = string.Empty;

		public Pivotal(string username, string password)
		{
			Login(username, password);
			xmlserializers = new Dictionary<string, XmlSerializer>();
		}

		#region IPivotal Members

		string IPivotal.AddStory(Project project, IterationVersion iteration, Story pivotalstory)
		{
			var url = string.Concat(BaseURL, project.Id, "/stories");
			var storyXml = new StringBuilder();

			storyXml.AppendFormat("<story><story_type>{0}</story_type><name>{1}</name><requested_by>{2}</requested_by>",
			                      pivotalstory.Type, pivotalstory.Name, pivotalstory.RequestedBy);
			if (!string.IsNullOrEmpty(pivotalstory.Description))
			{
				storyXml.AppendFormat("<description>{0}</description>", pivotalstory.Description);
			}
			storyXml.AppendFormat("<current_state>{0}</current_state>", pivotalstory.CurrentState);

			storyXml.Append("</story>");
			return SendResponseToServer(url, storyXml.ToString(), RequestMethodType.POST);
		}

		Project IPivotal.GetProjectById(int id)
		{
			return FromXml<Project>(GetPivotalResponse(string.Concat(BaseURL, id)));
		}

		IEnumerable<Project> IPivotal.GetAllProjects()
		{
			return
				FromXml<Projects>(
					GetPivotalResponse(BaseURL)).projects;
		}

		IEnumerable<Iteration> IPivotal.GetIteration(Project project, IterationVersion iterationToRetrieve)
		{
			return GetIteration(project.Id, iterationToRetrieve);
		}

		public IEnumerable<Iteration> GetIteration(int projectId, IterationVersion iterationToRetrieve)
		{
			var iterationsfilter = Enum.GetName(typeof (IterationVersion), iterationToRetrieve).ToLower();
			iterationsfilter = iterationsfilter != "all" ? string.Concat("/", iterationsfilter) : string.Empty;

			var iterations =
				FromXml<Iterations>(
					GetPivotalResponse(string.Concat(BaseURL, projectId, "/iterations", iterationsfilter)));

			return iterations.iterations;
		}

		IEnumerable<Story> IPivotal.GetStoriesByFilter(Project project, string filter)
		{
			var stories =
				FromXml<Stories>(
					GetPivotalResponse(string.Concat(BaseURL, project.Id, "/stories?filter=", filter)));

			return stories.stories;
		}

		void IPivotal.SaveStory(Project project, Story story)
		{
			ValidateStoryObject(story);

			var serializedobject = ToXml(story);

			var url = story.CreatedAt == null
				          ? string.Concat(BaseURL, project.Id, "/stories")
				          : string.Concat(BaseURL, project.Id, "/stories/", story.Id);

			SendResponseToServer(url, serializedobject, RequestMethodType.PUT);
		}

		public void UpdatePivotalStoryStatus(Project project, Story story)
		{
			ValidateStoryObject(story);

			var sb = new StringBuilder();

			sb.Append("<Story>");
			sb.Append("<current_state>");
			sb.Append(story.CurrentState);
			sb.Append("</current_state>");
			sb.Append("<Story>");
			var url = story.CreatedAt == null
				          ? string.Concat(BaseURL, project.Id, "/stories")
				          : string.Concat(BaseURL, project.Id, "/stories/", story.Id);

			SendResponseToServer(url, sb.ToString(), RequestMethodType.PUT);
		}

		Project IPivotal.GetProjectByName(string projectname)
		{
			var allProjects = FromXml<Projects>(GetPivotalResponse(BaseURL)).projects;
			return allProjects.Where(query => query.Name == projectname).First();
		}

		#endregion

		private static void ValidateStoryObject(Story story)
		{
			if (string.IsNullOrEmpty(story.RequestedBy))
				throw new ArgumentNullException("RequestedBy", "Isn't allowed to be null or empty");
			if (string.IsNullOrEmpty(story.Name))
				throw new ArgumentNullException("Name", "Isn't allowed to be null or empty");
		}

		private Story GetStoryById(Project project, int pivotalID)
		{
			//curl -H "X-TrackerToken: TOKEN" -X GET http://www.pivotaltracker.com/services/v3/projects/PROJECT_ID/stories/STORY_ID
			return FromXml<Story>(
				GetPivotalResponse(string.Concat(BaseURL, project.Id, "/stories/", pivotalID)));
		}

		private void Login(string username, string password)
		{
			var request = (HttpWebRequest) WebRequest.Create(TokenURL);

			// Set the Method property to 'POST' to post data to the URI. 
			request.Method = "POST";

			//request.Proxy = WebProxy.GetDefaultProxy();

			var byteArray = Encoding.UTF8.GetBytes(string.Concat("username=", username, "&password=", password));

			request.ContentLength = byteArray.Length;

			var dataStream = request.GetRequestStream();
			dataStream.Write(byteArray, 0, byteArray.Length);

			dataStream.Close();

			var objStream = request.GetResponse().GetResponseStream();

			var xmlDoc = new XmlDocument();

			xmlDoc.LoadXml(GetStringFromStream(objStream));

			token = xmlDoc.GetElementsByTagName("guid").Item(0).InnerText;
		}

		private static string GetStringFromStream(Stream objStream)
		{
			var objReader = new StreamReader(objStream);
			return objReader.ReadToEnd();
		}

		private string GetPivotalResponse(string url)
		{
			var request = (HttpWebRequest) WebRequest.Create(url);

			//request.Proxy = WebProxy.GetDefaultProxy();
			request.Headers.Add("X-TrackerToken", token);

			return GetStringFromStream(request.GetResponse().GetResponseStream());
		}

		//Creates an object from an XML string.
		private static T FromXml<T>(string xml)
		{
			XmlSerializer ser;
			var fullname = string.Empty + typeof (T).FullName;
			if (xmlserializers.ContainsKey(fullname))
				ser = xmlserializers[fullname];
			else
			{
				ser = new XmlSerializer(typeof (T));
				xmlserializers.Add(fullname, ser);
			}

			var stringReader = new StringReader(xml);
			var xmlReader = new XmlTextReader(stringReader);
			var obj = (T) ser.Deserialize(xmlReader);
			xmlReader.Close();
			stringReader.Close();
			return obj;
		}

		private static string ToXml(object objectToSerialize)
		{
			try
			{
				String xmlizedString = null;
				var memoryStream = new MemoryStream();
				var xs = new XmlSerializer(objectToSerialize.GetType());
				var ns = new XmlSerializerNamespaces();

				//Add an empty namespace and empty value
				ns.Add(string.Empty, string.Empty);

				var xmlWriterSettings = new XmlWriterSettings
					{
						OmitXmlDeclaration = true,
						ConformanceLevel = ConformanceLevel.Document,
						CloseOutput = false,
					};

				var xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);

				xs.Serialize(xmlWriter, objectToSerialize, ns);
				memoryStream.Position = 0;
				xmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());

				return xmlizedString;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return null;
			}
		}

		private static String UTF8ByteArrayToString(Byte[] characters)
		{
			var encoding = new UTF8Encoding();
			var constructedString = encoding.GetString(characters);
			return (constructedString);
		}

		private string SendResponseToServer(string url, string data, RequestMethodType type)
		{
			var request = (HttpWebRequest) WebRequest.Create(AppendTokenToUrl(url));

			// Set the ContentType property. 
			request.ContentType = "application/xml";

			// Set the Method property to 'POST' to post data to the URI. 
			request.Method = type.ToString(); // "POST";

			//request.Proxy = WebProxy.GetDefaultProxy();

			var byteArray = Encoding.UTF8.GetBytes(data);

			request.ContentLength = byteArray.Length;
			Stream dataStream = null;
			try
			{
				dataStream = request.GetRequestStream();
				dataStream.Write(byteArray, 0, byteArray.Length);
			}
			catch (Exception ex)
			{
				//TODO: log error.
				return ex.Message;
			}
			finally
			{
				if (dataStream != null)
					dataStream.Close();
			}

			Stream objStream = null;
			try
			{
				objStream = request.GetResponse().GetResponseStream();
				return GetStringFromStream(objStream);
			}
			catch (Exception ex)
			{
				//TODO: logerror
				return ex.Message;
			}
			finally
			{
				if (objStream != null)
				{
					objStream.Close();
					objStream.Dispose();
				}
			}
		}

		private string AppendTokenToUrl(string url)
		{
			var tempurl = url;
			if (tempurl.EndsWith("/"))
				tempurl.Remove(tempurl.Length - 1, 1);

			tempurl = string.Concat(tempurl, "?token=", token);
			return tempurl;
		}

		private enum RequestMethodType
		{
			// ReSharper disable InconsistentNaming
			POST,

			PUT
			// ReSharper restore InconsistentNaming
		}
	}
}