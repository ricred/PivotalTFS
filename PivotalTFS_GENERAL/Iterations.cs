using System.Xml.Serialization;

namespace PivotalTFS_GENERAL
{
	[XmlRoot("iterations")]
	public class Iterations
	{
		[XmlElement("iteration")] public Iteration[] iterations;
	}
}