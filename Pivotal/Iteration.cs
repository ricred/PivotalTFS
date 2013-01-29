using System.Xml.Serialization;

namespace PivotalTFSSync
{
    [XmlRoot("iteration")]
    public class Iteration
    {
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "number")]
        public int Number { get; set; }

        [XmlElement(ElementName = "start")]
        public string Start { get; set; }

        [XmlElement(ElementName = "finish")]
        public string Finish { get; set; }

        [XmlElement(ElementName = "stories")]
        public Stories Stories { get; set; }
    }
}