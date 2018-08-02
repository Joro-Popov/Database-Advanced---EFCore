namespace ProductShop.Models.DTOs
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("product")]
    public class ProductDto
    {
        [XmlElement(ElementName = "name")]
        [MinLength(3)]
        public string Name { get; set; }

        [XmlElement(ElementName = "price")]
        public decimal Price { get; set; }
    }
}