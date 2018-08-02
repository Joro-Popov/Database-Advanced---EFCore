namespace ProductShop.Models.DTOs
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot(ElementName = "users")]
    public class UsersDto
    {
        [XmlAttribute(AttributeName = "count")]
        public int Count { get; set; }

        [XmlElement(ElementName = "user")]
        public List<UsersAndProductsDto> Users { get; set; }
    }
}