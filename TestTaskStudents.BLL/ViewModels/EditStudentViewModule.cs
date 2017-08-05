using System;
using System.Windows.Data;

using TestTaskStudents.BLL.Infrastructure;

namespace TestTaskStudents.BLL.ViewModels
{
    public class EditStudentViewModule
    {
        public StudentViewModel Student { get; set; }

        public EditStudentViewModule()
        {
            Student = new StudentViewModel();
        }
    }
}
