namespace CarDealer.Models.DTOs
{
    using System.Xml.Serialization;

    [XmlType("car")]
    public class FerrariDto
    {
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }

        [XmlAttribute(AttributeName = "model")]
        public string Model { get; set; }

        [XmlAttribute(AttributeName = "travelled-distance")]
        public ulong TravelledDistance { get; set; }
    }
}
