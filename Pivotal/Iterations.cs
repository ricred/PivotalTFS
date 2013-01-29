using System.Xml.Serialization;

namespace PivotalTFSSync
{
    [XmlRoot("iterations")]
    public class Iterations
    {
        [XmlElement("iteration")] public Iteration[] iterations;
    }
}