using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PivotalTFSSync;

namespace PivotalTFSTests.Unittests
{
	 
	[TestClass]
	public class Pivotal
	{
		[TestMethod]
		public void CanSaveStoryAndDeleteIt()
		{
			var p = new PivotalTrackerAPI.Pivotal("dd","dd");
			Project project= p.GetProjectByName("PivotalTFS");

			p.SaveStory(project, new Story() { Name = "testname", Description = "Description",RequestedBy="Rickard Redler",Type = "feature"});
		 
		//	var story = p.get
			
		}
	}
}
