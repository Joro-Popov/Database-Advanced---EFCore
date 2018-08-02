namespace ProductShop.Models.DTOs
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("category")]
    public class CategoryDto
    {
        [XmlElement(ElementName = "name")]
        [MinLength(3)]
        [MaxLength(15)]
        public string Name { get; set; }
    }
}