using System.Xml.Serialization;

namespace PivotalTFS_GENERAL
{
    [XmlRoot("projects")]
    public class Projects
    {
        [XmlElement("project")] public Project[] projects;
    }
}