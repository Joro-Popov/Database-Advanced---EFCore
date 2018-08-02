namespace ProductShop.Models.DTOs
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("user")]
    public class UserProductsDto
    {
        [XmlAttribute(AttributeName = "first-name")]
        public string FirstName { get; set; }

        [XmlAttribute(AttributeName = "last-name")]
        public string LastName { get; set; }

        [XmlArray(ElementName = "sold-products")]
        public List<ProductDto> Products { get; set; }
    }
}