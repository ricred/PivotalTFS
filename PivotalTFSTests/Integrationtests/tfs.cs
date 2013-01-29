using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PivotalTFSSync;

namespace PivotalTFSTests.Integrationtests
{
	/// <summary>
	/// Summary description for UnitTest1
	/// </summary>
	[TestClass]
	public class TFS
	{
		//private const string Domain = @"snd";
		//private const string Password = @"grodanboll232";
		//private const string Projectname = @"pivotaltfs";
		//private const string URL = @"https://tfs08.codeplex.com";
		//private const string Username = @"RickardRedler_cp";
		//private static ITFS tfsserver;
		private const string Domain = @"vgregion";
		private const string Password = @"Fisksoppa2323";
		private const string Projectname = @"Vardval";
		private const string URL = @"vgms0057.vgregion.se";
		private const string Username = @"ricre1";
		private static ITFS tfsserver;
		#region Additional test attributes

		//
		// You can use the following additional attributes as you write your tests:
		//
		// Use ClassInitialize to run code before running the first test in the class
		[ClassInitialize]
		public static void Initialize(TestContext testContext)
		{
			tfsserver = new PivotalTFSSync.TFS(URL, Domain, Username, Password);
			Assert.IsNotNull(tfsserver);
		}

		#endregion

		public TFS()
		{
			Assert.IsFalse(string.IsNullOrEmpty(URL), "URL cannot be empty");
			Assert.IsFalse(string.IsNullOrEmpty(Username), "Username cannot be empty");
			Assert.IsFalse(string.IsNullOrEmpty(Password), "Password cannot be empty");
			//Assert.IsFalse(string.IsNullOrEmpty(Domain), "Domain cannot be empty");
		}

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext { get; set; }

		[TestMethod]
		public void ReadoutExistingProjects()
		{
			ProjectCollection projects = tfsserver.GetProjects();
			Assert.IsNotNull(projects);
		}

		[TestMethod]
		public void GetIterationpathsForProject()
		{
			ProjectCollection projects = tfsserver.GetProjects();
			Assert.IsNotNull(projects);
			NodeCollection iterationpaths = tfsserver.GetIterationPaths(Projectname);
			Assert.IsNotNull(iterationpaths);
			Assert.IsTrue(iterationpaths.Count > 0);
		}
		[TestMethod]
		public void GetNextPriorityNumberAndPriorityStep()
		{
			ProjectCollection projects = tfsserver.GetProjects();
			Assert.IsNotNull(projects);
			NodeCollection iterationpaths = tfsserver.GetIterationPaths(Projectname);
			int nextPriority, priorityStep;

			tfsserver.GetNextPriorityNumberAndPriorityStep(Projectname, iterationpaths[0].Name, out nextPriority, out priorityStep);
			Assert.IsNotNull(iterationpaths);
			Assert.IsTrue(iterationpaths.Count > 0);
		}
	}
}