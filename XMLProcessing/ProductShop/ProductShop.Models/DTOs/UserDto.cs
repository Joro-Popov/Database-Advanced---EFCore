namespace ProductShop.Models.DTOs
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("user")]
    public class UserDto
    {
        [XmlAttribute(AttributeName = "firstName")]
        public string FirstName { get; set; }

        [XmlAttribute(AttributeName = "lastName")]
        [MinLength(3)]
        public string LastName { get; set; }

        [XmlAttribute(AttributeName = "age")]
        public string Age { get; set; }
    }
}