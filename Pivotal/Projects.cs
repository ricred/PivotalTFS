using System.Xml.Serialization;

namespace PivotalTFSSync
{
    [XmlRoot("projects")]
    public class Projects
    {
        [XmlElement("project")] public Project[] projects;
    }
}