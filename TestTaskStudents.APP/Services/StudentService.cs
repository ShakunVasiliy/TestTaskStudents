using System;
using System.Windows;

using TestTaskStudents.BLL.Interfaces;
using TestTaskStudents.BLL.ViewModels;
using TestTaskStudents.APP.Views;

namespace TestTaskStudents.APP.Services
{
    public class StudentService : IStudentService
    {
        #region IStudentService

        public StudentViewModel Create()
        {
            var createStudentWindow = new EditStudentWindow();
            var createResult = createStudentWindow.ShowDialog();

            return createResult == true ? ((EditStudentViewModel)createStudentWindow.DataContext).Student : null;
        }

        public bool Edit(StudentViewModel student)
        {
            var editStudentWindow = new EditStudentWindow(student);
            var editResult = editStudentWindow.ShowDialog();

            return editResult ?? false;
        }

        public bool Delete()
        {
            return MessageBox.Show("Delete selected students?", "Delete?", MessageBoxButton.OKCancel) == MessageBoxResult.OK ? true : false;
        }

        #endregion IStudentService
    }
}
