using System.Xml.Serialization;

namespace PivotalTFS_GENERAL
{
	[XmlRoot("project")]
	public class Project
	{
		[XmlElement(ElementName = "id")]
		public int Id { get; set; }

		[XmlElement(ElementName = "name")]
		public string Name { get; set; }

		[XmlElement(ElementName = "iteration_length")]
		public int IterationLength { get; set; }

		[XmlElement(ElementName = "week_start_day")]
		public string WeekStartDay { get; set; }

		[XmlElement(ElementName = "point_scale")]
		public string PointScale { get; set; }

		[XmlElement(ElementName = "veloicty_scheme")]
		public string VelocityScheme { get; set; }

		[XmlElement(ElementName = "initial_velocity")]
		public int InitialVelocity { get; set; }
	}
}