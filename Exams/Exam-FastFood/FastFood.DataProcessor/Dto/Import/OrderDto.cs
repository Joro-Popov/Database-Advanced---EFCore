namespace FastFood.DataProcessor.Dto.Import
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Order")]
    public class OrderDto
    {
        public int Id { get; set; }

        [XmlElement()]
        [Required]
        public string Customer { get; set; }

        [XmlElement()]
        [MinLength(3)]
        [MaxLength(30)]
        [Required]
        public string Employee { get; set; }

        [XmlElement()]
        [Required]
        public string DateTime { get; set; }

        [XmlElement()]
        [Required]
        public string Type { get; set; }

        [XmlArray()]
        public List<OrderItemsDto> Items { get; set; }
    }
}
