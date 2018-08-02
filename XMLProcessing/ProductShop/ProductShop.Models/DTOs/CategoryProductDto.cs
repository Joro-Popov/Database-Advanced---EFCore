using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ProductShop.Models.DTOs
{
    [XmlType("category")]
    public class CategoryProductDto
    {
        [XmlAttribute(AttributeName = "name")]
        [MinLength(3)]
        [MaxLength(15)]
        public string Name { get; set; }

        [XmlElement(ElementName = "products-count")]
        public int NumberOfProducts { get; set; }

        [XmlElement(ElementName = "average-price")]
        public decimal AveragePrice { get; set; }

        [XmlElement(ElementName = "total-revenue")]
        public decimal TotalRevenue { get; set; }
    }
}