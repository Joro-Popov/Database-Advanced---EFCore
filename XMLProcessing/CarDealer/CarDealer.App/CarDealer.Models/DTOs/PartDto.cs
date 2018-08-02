namespace CarDealer.Models.DTOs
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("part")]
    public class PartDto
    {
        [XmlAttribute(AttributeName = "name")]
        [MinLength(3)]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "price")]
        public decimal Price { get; set; }

        [XmlAttribute(AttributeName = "quantity")]
        public int Quantity { get; set; }
    }
}
