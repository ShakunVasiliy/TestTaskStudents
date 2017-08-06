using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestTaskStudents.DAL.Infrastructure;
using TestTaskStudents.DAL.Interfaces;
using TestTaskStudents.DAL.Models;

namespace TestTaskStudents.DAL.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private static string rootElementName = "Students";
        private static string studentElementName = "Student";
        private static string idAttributeName = "Id";
        private static string firstNameElementName = "FirstName";
        private static string lastNameElementName = "Last";
        private static string ageElementName = "Age";
        private static string genderElementName = "Gender";

        private string xDocPath;
        private XDocument xDoc;
        private XElement xStudents;
        private int lastStudentId;

        public StudentRepository(string path)
        {
            xDocPath = path;
            xDoc = XDocument.Load(path);
            xStudents = xDoc.Element(rootElementName);
            lastStudentId = GetLastStudentId();
        }

        private int GetLastStudentId()
        {
            IEnumerable<Student> students = GetAll();

            return (students.Count() > 0) ? students.Max(student => student.Id) : 0;
        }

        #region IStudentRepository

        public IEnumerable<Student> GetAll()
        {
            return (from studentElement in xStudents.Elements(studentElementName)
                    select new Student()
                    {
                        Id = int.Parse(studentElement.Attribute(idAttributeName).Value),
                        FirstName = studentElement.Element(firstNameElementName).Value,
                        LastName = studentElement.Element(lastNameElementName).Value,
                        Age = int.Parse(studentElement.Element(ageElementName).Value),
                        Gender = (Gender)int.Parse(studentElement.Element(genderElementName).Value)
                    }).ToList();
        }

        public void Add(Student student)
        {
            student.Id = ++lastStudentId;

            XElement studentElement = new XElement(studentElementName, 
                new XAttribute(idAttributeName, student.Id),
                new XElement(firstNameElementName, student.FirstName),
                new XElement(lastNameElementName, student.LastName),
                new XElement(ageElementName, student.Age),
                new XElement(genderElementName, (int)student.Gender));

            xStudents.Add(studentElement);
        }

        public void Delete(Student student)
        {
            XElement xStudent = (from studentElement in xStudents.Elements(studentElementName)
                                 where studentElement.Attribute(idAttributeName).Value == student.Id.ToString()
                                 select studentElement).FirstOrDefault();

            if (xStudent == null) return;

            xStudent.Remove();
        }

        public void Save()
        {
            xStudents.Save(xDocPath);
        }

        #endregion IStudentRepository
    }
}
