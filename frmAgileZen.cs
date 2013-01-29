using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using PIVOTAL_API;
using PrearrangedChaos.AgileZen.Service;
using PrearrangedChaos.AgileZen.Service.Model;
using TFS_API.TFS;
using Project = Microsoft.TeamFoundation.WorkItemTracking.Client.Project;
using Story = PIVOTAL_API.Story;

namespace PivotalTFSSync
{
	public partial class frmAgileZen : Form
	{
		public frmAgileZen()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var service = new ZenService
			{
				PageSize = 50,
				ApiKey = "595c7575aa60450aa24e67002db13311"
			};
			const int projectId = 28409;

			//Get story with metrics and details
			var existingStory = service.GetStories(projectId).WithTasks.WithDetails.WithComments;//.WithComments.WithTasks.WithDetails();
			
				var tfs = new TFS2010("knoxas02:8080", "knowit",
								  "ricred", "Sommarvatten2312");

			var name = "GBG_SYS_THERM_HPC";
					//((Project)cboTFSProjects.SelectedItem).Name;

			var map = AutoMapper.Mapper.CreateMap<PrearrangedChaos.AgileZen.Service.Model.IStory, PIVOTAL_API.Story>();
			map.ForMember(s => s.Name, m => m.MapFrom(f => f.Text));
			map.ForMember(s => s.Description, m => m.MapFrom(f => f.Details));
			map.ForMember(s => s.RequestedBy, m => m.MapFrom(f => f.Creator));
			map.ForMember(s => s.Estimate, m => m.MapFrom(f => f.Size));
			//map.ForMember(s => s.Tasks, m => m.MapFrom(f => f.Tasks));
			//map.ForMember(s => s.Tasks, m => m.MapFrom(f => f.Tasks));
			AutoMapper.Mapper.CreateMap(typeof(ITask), typeof(Tasks));
	 
			foreach (var story in existingStory)
			{
				var pivotalstory = new Story() ;
				pivotalstory.Name = story.Text;
				pivotalstory.Description = story.Details;
				pivotalstory.RequestedBy = story.Creator.Name;
				pivotalstory.Estimate = Convert.ToInt32(story.Size);
				pivotalstory.Id = story.Id;
				//pivotalstory.Tasks.tasks=story.Tasks.Select((s)=>new Tasks(){tasks = })
					AutoMapper.Mapper.Map(story, pivotalstory);
					tfs.AddPivotalStoryToTFS(pivotalstory, name, ((Node)cboTFSIterations.SelectedItem).Name,
					                         ((Node)cboTFSSubPath.SelectedItem).Name, null, false);
			}

		}
	}
}
