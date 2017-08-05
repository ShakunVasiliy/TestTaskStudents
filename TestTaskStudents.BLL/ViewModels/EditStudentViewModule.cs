using System;
using System.Windows.Data;

using TestTaskStudents.BLL.Infrastructure;

namespace TestTaskStudents.BLL.ViewModels
{
    public class EditStudentViewModule
    {
        public StudentViewModel Student { get; set; }
        public IValueConverter GenderConverter { get;}

        public EditStudentViewModule()
        {
            Student = new StudentViewModel();
            GenderConverter = new GenderConverter();
        }
    }
}
