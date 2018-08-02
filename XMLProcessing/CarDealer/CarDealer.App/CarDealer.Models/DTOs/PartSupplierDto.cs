namespace CarDealer.Models.DTOs
{
    using System.Xml.Serialization;

    [XmlType("part")]
    public class PartSupplierDto
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "price")]
        public decimal Price { get; set; }
    }
}
