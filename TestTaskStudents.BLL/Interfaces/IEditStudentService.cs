using System;

using TestTaskStudents.BLL.ViewModels;

namespace TestTaskStudents.BLL.Interfaces
{
    public interface IStudentService
    {
        bool Edit(StudentViewModel student);
        StudentViewModel Create();
    }
}
