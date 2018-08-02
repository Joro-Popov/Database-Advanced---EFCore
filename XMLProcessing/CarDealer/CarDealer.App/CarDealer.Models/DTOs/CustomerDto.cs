namespace CarDealer.Models.DTOs
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("customer")]
    public class CustomerDto
    {
        [XmlAttribute(AttributeName = "name")]
        [MinLength(3)]
        public string Name { get; set; }

        [XmlElement(ElementName = "birth-date")]
        [Required]
        public DateTime BirthDate { get; set; }

        [XmlElement(ElementName = "is-younger-driver")]
        public bool IsYounger { get; set; }
    }
}
