using System;

using TestTaskStudents.BLL.ViewModels;

namespace TestTaskStudents.BLL.Commands
{
    public class EditStudentCommand : RelayCommand
    {
        public EditStudentCommand(StudentsViewModel studentsViewModel)
            : base(obj =>
            {
                ;
            })
        { }
    }
}
