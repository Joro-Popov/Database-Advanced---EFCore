namespace P01_StudentsXML
{
    using P01_StudentsXML.Models;
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            var serializer = new XmlSerializer(typeof(StudentDto[]), new XmlRootAttribute("students"));
            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });
            var path = "../../../student.xml";

            var students = GetStudents();

            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, students, namespaces);
            }
        }

        private static StudentDto[] GetStudents()
        {
            var firstStudent = new StudentDto()
            {
                Name = "Georgi Popov",
                Gender = "Male",
                BirthDate = new DateTime(1993, 04, 04),
                PhoneNumber = "08878771113",
                Email = "popov937@abv.bg",
                University = "SoftUni",
                Speciality = ".NET Web Developer",
                FacultyNumber = "00001222",
                Exams = new ExamDto[2]
                {
                    new ExamDto()
                    {
                        Name = "Database Basics",
                        DateTaken = new DateTime(2018, 05, 24),
                        Grade = 6.00m
                    },
                    new ExamDto()
                    {
                        Name = "C# OOP Advanced",
                        DateTaken = new DateTime(2018, 04, 22),
                        Grade = 6.00m
                    },
                }
            };

            var secondStudent = new StudentDto()
            {
                Name = "Ivan Ivanov",
                Gender = "Male",
                BirthDate = new DateTime(1999, 04, 04),
                PhoneNumber = "0887281216",
                Email = "popov937@abv.bg",
                University = "SoftUni",
                Speciality = "Java Web Developer",
                FacultyNumber = "00001222",
                Exams = new ExamDto[2]
                {
                    new ExamDto()
                    {
                        Name = "Database Basics",
                        DateTaken = new DateTime(2018, 05, 24),
                        Grade = 6.00m
                    },
                    new ExamDto()
                    {
                        Name = "Programming Basics",
                        DateTaken = new DateTime(2018, 07, 22),
                        Grade = 6.00m
                    },
                }
            };

            return new StudentDto[] { firstStudent, secondStudent };
        }
    }
}
