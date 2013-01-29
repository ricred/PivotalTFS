using System.Xml.Serialization;

namespace PivotalTFSSync
{
    [XmlRoot("stories")]
    public class Stories
    {
        [XmlElement("story")] public Story[] stories;
    }
}