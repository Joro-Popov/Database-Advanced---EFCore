namespace CarDealer.Models.DTOs
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("supplier")]
    public class SupplierDto
    {
        [XmlAttribute(AttributeName = "name")]
        [MinLength(3)]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "is-importer")]
        public bool IsImporter { get; set; }
    }
}
