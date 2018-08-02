namespace P01_StudentsXML.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("student")]
    public class StudentDto
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "gender")]
        public string Gender { get; set; }

        [XmlElement(ElementName = "birthDate")]
        [DisplayFormat(DataFormatString = "yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz")]
        public DateTime BirthDate { get; set; }

        [XmlElement(ElementName = "phoneNumber", IsNullable = true)]
        public string PhoneNumber { get; set; }

        [XmlElement(ElementName = "email")]
        public string Email { get; set; }

        [XmlElement(ElementName = "university")]
        public string University { get; set; }

        [XmlElement(ElementName = "speciality")]
        public string Speciality { get; set; } 

        [XmlElement(ElementName = "facultyNumber", IsNullable = true)]
        public string FacultyNumber { get; set; }

        [XmlArray(ElementName = "exams")]
        public ExamDto[] Exams { get; set; }
    }
}
