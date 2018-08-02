namespace CarDealer.Models.DTOs
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("car")]
    public class CarPartsDto
    {
        [XmlAttribute(AttributeName = "make")]
        public string Make { get; set; }

        [XmlAttribute(AttributeName = "model")]
        public string Model { get; set; }

        [XmlAttribute(AttributeName = "travelled-distance")]
        public ulong TravelledDistance { get; set; }

        [XmlElement(ElementName = "parts")]
        public List<PartSupplierDto> Parts { get; set; }
    }
}
