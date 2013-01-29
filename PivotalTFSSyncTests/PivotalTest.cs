using PivotalTrackerAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PivotalTFSSync;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PivotalTFSSyncTests
{
    
    
    /// <summary>
    ///This is a test class for PivotalTest and is intended
    ///to contain all PivotalTest Unit Tests
    ///</summary>
	[TestClass()]
	public class PivotalTest
	{


		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		// 
		//You can use the following additional attributes as you write your tests:
		//
		//Use ClassInitialize to run code before running the first test in the class
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//Use ClassCleanup to run code after all tests in a class have run
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//Use TestInitialize to run code before running each test
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//Use TestCleanup to run code after each test has run
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion


		/// <summary>
		///A test for ser_UnreferencedObject
		///</summary>
		[TestMethod()]
		[DeploymentItem("PivotalTFSSync.exe")]
		public void ser_UnreferencedObjectTest()
		{
			object sender = null; // TODO: Initialize to an appropriate value
			UnreferencedObjectEventArgs e = null; // TODO: Initialize to an appropriate value
			Pivotal_Accessor.ser_UnreferencedObject(sender, e);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for ser_UnknownNode
		///</summary>
		[TestMethod()]
		[DeploymentItem("PivotalTFSSync.exe")]
		public void ser_UnknownNodeTest()
		{
			object sender = null; // TODO: Initialize to an appropriate value
			XmlNodeEventArgs e = null; // TODO: Initialize to an appropriate value
			Pivotal_Accessor.ser_UnknownNode(sender, e);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for ser_UnknownElement
		///</summary>
		[TestMethod()]
		[DeploymentItem("PivotalTFSSync.exe")]
		public void ser_UnknownElementTest()
		{
			object sender = null; // TODO: Initialize to an appropriate value
			XmlElementEventArgs e = null; // TODO: Initialize to an appropriate value
			Pivotal_Accessor.ser_UnknownElement(sender, e);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for ser_UnknownAttribute
		///</summary>
		[TestMethod()]
		[DeploymentItem("PivotalTFSSync.exe")]
		public void ser_UnknownAttributeTest()
		{
			object sender = null; // TODO: Initialize to an appropriate value
			XmlAttributeEventArgs e = null; // TODO: Initialize to an appropriate value
			Pivotal_Accessor.ser_UnknownAttribute(sender, e);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for PivotalTFSSync.IPivotal.GetProjectById
		///</summary>
		[TestMethod()]
		[DeploymentItem("PivotalTFSSync.exe")]
		public void GetProjectByIdTest1()
		{
			string username = string.Empty; // TODO: Initialize to an appropriate value
			string password = string.Empty; // TODO: Initialize to an appropriate value
			IPivotal target = new Pivotal(username, password); // TODO: Initialize to an appropriate value
			int id = 0; // TODO: Initialize to an appropriate value
			Project expected = null; // TODO: Initialize to an appropriate value
			Project actual;
			actual = target.GetProjectById(id);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for PivotalTFSSync.IPivotal.GetIteration
		///</summary>
		[TestMethod()]
		[DeploymentItem("PivotalTFSSync.exe")]
		public void GetIterationTest1()
		{
			string username = string.Empty; // TODO: Initialize to an appropriate value
			string password = string.Empty; // TODO: Initialize to an appropriate value
			IPivotal target = new Pivotal(username, password); // TODO: Initialize to an appropriate value
			Project project = null; // TODO: Initialize to an appropriate value
			Pivotal.IterationVersion iterationToRetrieve = new Pivotal.IterationVersion(); // TODO: Initialize to an appropriate value
			IEnumerable<Iteration> expected = null; // TODO: Initialize to an appropriate value
			IEnumerable<Iteration> actual;
			actual = target.GetIteration(project, iterationToRetrieve);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for PivotalTFSSync.IPivotal.GetAllProjects
		///</summary>
		[TestMethod()]
		[DeploymentItem("PivotalTFSSync.exe")]
		public void GetAllProjectsTest1()
		{
			string username = string.Empty; // TODO: Initialize to an appropriate value
			string password = string.Empty; // TODO: Initialize to an appropriate value
			IPivotal target = new Pivotal(username, password); // TODO: Initialize to an appropriate value
			IEnumerable<Project> expected = null; // TODO: Initialize to an appropriate value
			IEnumerable<Project> actual;
			actual = target.GetAllProjects();
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for PivotalTFSSync.IPivotal.AddStory
		///</summary>
		[TestMethod()]
		[DeploymentItem("PivotalTFSSync.exe")]
		public void AddStoryTest1()
		{
			string username = string.Empty; // TODO: Initialize to an appropriate value
			string password = string.Empty; // TODO: Initialize to an appropriate value
			IPivotal target = new Pivotal(username, password); // TODO: Initialize to an appropriate value
			Project project = null; // TODO: Initialize to an appropriate value
			Pivotal.IterationVersion iteration = new Pivotal.IterationVersion(); // TODO: Initialize to an appropriate value
			string name = string.Empty; // TODO: Initialize to an appropriate value
			string requestedBy = string.Empty; // TODO: Initialize to an appropriate value
			string storytype = string.Empty; // TODO: Initialize to an appropriate value
			string description = string.Empty; // TODO: Initialize to an appropriate value
			target.AddStory(project, iteration, name, requestedBy, storytype, description);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for Login
		///</summary>
		[TestMethod()]
		[DeploymentItem("PivotalTFSSync.exe")]
		public void LoginTest()
		{
			PrivateObject param0 = null; // TODO: Initialize to an appropriate value
			Pivotal_Accessor target = new Pivotal_Accessor(param0); // TODO: Initialize to an appropriate value
			string username = string.Empty; // TODO: Initialize to an appropriate value
			string password = string.Empty; // TODO: Initialize to an appropriate value
			target.Login(username, password);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for GetPivotalResponse
		///</summary>
		[TestMethod()]
		[DeploymentItem("PivotalTFSSync.exe")]
		public void GetPivotalResponseTest()
		{
			PrivateObject param0 = null; // TODO: Initialize to an appropriate value
			Pivotal_Accessor target = new Pivotal_Accessor(param0); // TODO: Initialize to an appropriate value
			string url = string.Empty; // TODO: Initialize to an appropriate value
			StringBuilder expected = null; // TODO: Initialize to an appropriate value
			StringBuilder actual;
			actual = target.GetPivotalResponse(url);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for FromXml
		///</summary>
		public void FromXmlTestHelper<T>()
		{
			string Xml = string.Empty; // TODO: Initialize to an appropriate value
			T expected = default(T); // TODO: Initialize to an appropriate value
			T actual;
			actual = Pivotal_Accessor.FromXml<T>(Xml);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		[TestMethod()]
		[DeploymentItem("PivotalTFSSync.exe")]
		public void FromXmlTest()
		{
			FromXmlTestHelper<GenericParameterHelper>();
		}

		/// <summary>
		///A test for AddStoryOrTask
		///</summary>
		[TestMethod()]
		[DeploymentItem("PivotalTFSSync.exe")]
		public void AddStoryOrTaskTest()
		{
			PrivateObject param0 = null; // TODO: Initialize to an appropriate value
			Pivotal_Accessor target = new Pivotal_Accessor(param0); // TODO: Initialize to an appropriate value
			string url = string.Empty; // TODO: Initialize to an appropriate value
			string data = string.Empty; // TODO: Initialize to an appropriate value
			target.AddStoryOrTask(url, data);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for Pivotal Constructor
		///</summary>
		[TestMethod()]
		public void PivotalConstructorTest()
		{
			string username = string.Empty; // TODO: Initialize to an appropriate value
			string password = string.Empty; // TODO: Initialize to an appropriate value
			Pivotal target = new Pivotal(username, password);
			Assert.Inconclusive("TODO: Implement code to verify target");
		}

		/// <summary>
		///A test for GetProjectById
		///</summary>
		[TestMethod()]
		public void GetProjectByIdTest()
		{
			string username = string.Empty; // TODO: Initialize to an appropriate value
			string password = string.Empty; // TODO: Initialize to an appropriate value
			IPivotal target = new Pivotal(username, password); // TODO: Initialize to an appropriate value
			int id = 0; // TODO: Initialize to an appropriate value
			Project expected = null; // TODO: Initialize to an appropriate value
			Project actual;
			actual = target.GetProjectById(id);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for GetIteration
		///</summary>
		[TestMethod()]
		public void GetIterationTest()
		{
			string username = string.Empty; // TODO: Initialize to an appropriate value
			string password = string.Empty; // TODO: Initialize to an appropriate value
			IPivotal target = new Pivotal(username, password); // TODO: Initialize to an appropriate value
			Project project = null; // TODO: Initialize to an appropriate value
			Pivotal.IterationVersion iterationToRetrieve = new Pivotal.IterationVersion(); // TODO: Initialize to an appropriate value
			IEnumerable<Iteration> expected = null; // TODO: Initialize to an appropriate value
			IEnumerable<Iteration> actual;
			actual = target.GetIteration(project, iterationToRetrieve);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for GetAllProjects
		///</summary>
		[TestMethod()]
		public void GetAllProjectsTest()
		{
			string username = string.Empty; // TODO: Initialize to an appropriate value
			string password = string.Empty; // TODO: Initialize to an appropriate value
			IPivotal target = new Pivotal(username, password); // TODO: Initialize to an appropriate value
			IEnumerable<Project> expected = null; // TODO: Initialize to an appropriate value
			IEnumerable<Project> actual;
			actual = target.GetAllProjects();
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for AddStory
		///</summary>
		[TestMethod()]
		public void AddStoryTest()
		{
			string username = string.Empty; // TODO: Initialize to an appropriate value
			string password = string.Empty; // TODO: Initialize to an appropriate value
			IPivotal target = new Pivotal(username, password); // TODO: Initialize to an appropriate value
			Project project = null; // TODO: Initialize to an appropriate value
			Pivotal.IterationVersion iteration = new Pivotal.IterationVersion(); // TODO: Initialize to an appropriate value
			string name = string.Empty; // TODO: Initialize to an appropriate value
			string requestedBy = string.Empty; // TODO: Initialize to an appropriate value
			string storytype = string.Empty; // TODO: Initialize to an appropriate value
			string description = string.Empty; // TODO: Initialize to an appropriate value
			target.AddStory(project, iteration, name, requestedBy, storytype, description);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}
	}
}
