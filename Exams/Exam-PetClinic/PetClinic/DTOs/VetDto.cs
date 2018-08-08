namespace PetClinic.DTOs
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Vet")]
    public class VetDto
    {
        [XmlElement()]
        [MinLength(3)]
        [MaxLength(40)]
        [Required]
        public string Name { get; set; }

        [XmlElement()]
        [MinLength(3)]
        [MaxLength(50)]
        [Required]
        public string Profession { get; set; }

        [XmlElement()]
        [Range(22, 65)]
        [Required]
        public int Age { get; set; }

        [XmlElement()]
        [RegularExpression(@"^(\+359|0)[0-9]{9}")]
        [Required]
        public string PhoneNumber { get; set; }
    }
}
