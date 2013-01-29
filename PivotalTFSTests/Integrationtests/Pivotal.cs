using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PivotalTFSSync;

namespace PivotalTFSTests.Integrationtests
{
	/// <summary>
	/// Summary description for Pivotal
	/// </summary>
	[TestClass]
	public class Pivotal
	{
		private const string Domain = @"snd";
		private const string Password = @"grodanboll232";
		private const string Projectname = @"pivotaltfs";
		private const string URL = @"https://tfs08.codeplex.com";
		private const string Username = @"RickardRedler_cp";
		private static IPivotal pivotalserver;

		[TestMethod]
		public void TestToSaveStory()
		{
			 
		}
	}
}
