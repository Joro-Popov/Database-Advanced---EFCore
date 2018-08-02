namespace ProductShop.Models.DTOs
{
    using System.Xml.Serialization;

    [XmlType("user")]
    public class UsersAndProductsDto
    {
        [XmlAttribute(AttributeName = "first-name")]
        public string FirstName { get; set; }

        [XmlAttribute(AttributeName = "last-name")]
        public string LastName { get; set; }

        [XmlAttribute(AttributeName = "age")]
        public int Age { get; set; }

        [XmlElement(ElementName = "sold-products")]
        public SoldProductsDto SoldProduct { get; set; }
    }
}