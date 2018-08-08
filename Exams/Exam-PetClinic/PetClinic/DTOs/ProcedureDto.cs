namespace PetClinic.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Procedure")]
    public class ProcedureDto
    {
        public int Id { get; set; }

        [XmlElement(ElementName = "Vet")]
        [MinLength(3)]
        [MaxLength(40)]
        [Required]
        public string VetName { get; set; }

        [XmlElement(ElementName = "Animal")]
        [RegularExpression("^[A-z]{7}[0-9]{3}$")]
        [Required]
        public string AnimalPassportNumber { get; set; }

        [XmlElement()]
        [Required]
        public string DateTime { get; set; }

        [XmlArray()]
        public List<AnimalAidDto> AnimalAids { get; set; }
        
    }
}
