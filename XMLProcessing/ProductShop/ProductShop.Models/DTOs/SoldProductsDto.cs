namespace ProductShop.Models.DTOs
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("sold-products")]
    public class SoldProductsDto
    {
        [XmlAttribute(AttributeName = "count")]
        public int Count { get; set; }

        [XmlElement(ElementName = "product")]
        public List<ProductUserDto> Products { get; set; }
    }
}