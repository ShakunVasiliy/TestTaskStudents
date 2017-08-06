using System;
using System.Windows.Input;

using TestTaskStudents.BLL.DTO;

namespace TestTaskStudents.BLL.Interfaces
{
    public interface IEditStudentViewModel
    {
        StudentDTO Student { get; set; }
        ICommand SaveCommand { get; }
    }
}
