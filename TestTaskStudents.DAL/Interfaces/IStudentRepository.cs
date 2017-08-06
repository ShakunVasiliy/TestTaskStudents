using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestTaskStudents.DAL.Models;

namespace TestTaskStudents.DAL.Interfaces
{
    public interface IStudentRepository : IDisposable
    {
        IEnumerable<Student> GetAll();
        void Add(Student student);
        void Save();
    }
}
