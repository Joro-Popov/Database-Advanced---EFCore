namespace SoftJail.DataProcessor.ImportDto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Officer")]
    public class OfficerDto
    {
        public int Id { get; set; }

        [XmlElement()]
        [MinLength(3)]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [XmlElement(ElementName = "Money")]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        [Required]
        public decimal Salary { get; set; }

        [XmlElement()]
        [Required]
        public string Position { get; set; }

        [XmlElement()]
        [Required]
        public string Weapon { get; set; }

        [XmlElement()]
        [Required]
        public int DepartmentId { get; set; }

        [XmlArray()]
        public List<OfficerPrisonerDto> Prisoners { get; set; }
    }
}
