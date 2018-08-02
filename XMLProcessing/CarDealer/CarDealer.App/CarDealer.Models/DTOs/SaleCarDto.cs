namespace CarDealer.Models.DTOs
{
    using System;
    using System.Xml.Serialization;

    public class SaleCarDto
    {
        [XmlAttribute(AttributeName = "make")]
        public string Make { get; set; }

        [XmlAttribute(AttributeName = "model")]
        public string Model { get; set; }

        [XmlAttribute(AttributeName = "travelled-distance")]
        public ulong TravelledDistance { get; set; }
    }
}
