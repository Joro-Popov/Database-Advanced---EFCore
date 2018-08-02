namespace ProductShop.Models.DTOs
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("product")]
    public class ProductRangeDto
    {
        [XmlAttribute(AttributeName = "name")]
        [MinLength(3)]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "price")]
        public decimal Price { get; set; }

        [XmlAttribute(AttributeName = "buyer")]
        public string BuyerName { get; set; }
    }
}