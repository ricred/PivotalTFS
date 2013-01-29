using System.Xml.Serialization;

namespace PivotalTFS_GENERAL
{
	[XmlRoot("stories")]
	public class Stories
	{
		[XmlElement("story")] public Story[] stories;
	}

	[XmlRoot("tasks")]
	public class Tasks
	{
		[XmlElement("task")] public Task[] tasks;
	}
}