namespace CarDealer.Models.DTOs
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("car")]
    public class CarDto
    {
        [XmlElement(ElementName = "make")]
        [MinLength(3)]
        public string Make { get; set; }

        [XmlElement(ElementName = "model")]
        [MinLength(3)]
        public string Model { get; set; }

        [XmlElement(ElementName = "travelled-distance")]
        public ulong TravelledDistance { get; set; }
    }
}
