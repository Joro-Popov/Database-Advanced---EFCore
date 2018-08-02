namespace P01_StudentsXML.Models
{
    using System;
    using System.Xml.Serialization;
    
    [XmlType("exam")]
    public class ExamDto
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "dateTaken")]
        public DateTime DateTaken { get; set; }

        [XmlElement(ElementName = "grade")]
        public decimal Grade { get; set; }
    }
}
