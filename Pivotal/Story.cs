using System.Xml.Serialization;

namespace PivotalTFSSync
{
    [XmlRoot(ElementName = "story")]
    public class Story
    {
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "url")]
        public string URL { get; set; }

        [XmlElement(ElementName = "estimate")]
        public int Estimate { get; set; }

        [XmlElement(ElementName = "current_state")]
        public string CurrentState { get; set; }

        [XmlElement(ElementName = "owned_by")]
        public string OwnedBy { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "story_type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "requested_by")]
        public string RequestedBy { get; set; }

        [XmlElement(ElementName = "created_at")]
        public string CreatedAt { get; set; }

        [XmlElement(ElementName = "accepted_at")]
        public string AcceptedAt { get; set; }

        [XmlElement(ElementName = "labels")]
        public string Labels { get; set; }

        public int Priority { get; set; }
    }
}