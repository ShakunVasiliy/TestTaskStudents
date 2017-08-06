using System;

using TestTaskStudents.BLL.DTO;

namespace TestTaskStudents.BLL.Interfaces
{
    public interface IStudentService
    {
        bool Edit(StudentDTO student);
        StudentDTO Create();
        bool Delete();
    }
}
