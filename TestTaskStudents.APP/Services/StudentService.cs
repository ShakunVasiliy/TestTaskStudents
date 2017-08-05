using System;

using TestTaskStudents.BLL.Interfaces;
using TestTaskStudents.BLL.ViewModels;
using TestTaskStudents.APP.Views;

namespace TestTaskStudents.APP.Services
{
    public class StudentService : IStudentService
    {
        public StudentViewModel Create()
        {
            var createStudentWindow = new EditStudentWindow();
            var createResult = createStudentWindow.ShowDialog();

            return createResult == true ? (StudentViewModel)createStudentWindow.DataContext : null;
        }

        public bool Edit(StudentViewModel student)
        {
            var editStudentWindow = new EditStudentWindow(student);
            var editResult = editStudentWindow.ShowDialog();

            return editResult ?? false;
        }
    }
}
