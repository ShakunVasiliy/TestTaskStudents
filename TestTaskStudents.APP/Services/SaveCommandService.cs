using System;

using TestTaskStudents.BLL.Interfaces;
using TestTaskStudents.APP.Views;

namespace TestTaskStudents.APP.Services
{
    public class SaveCommandService : ISaveCommandService
    {
        #region ISaveCommandService

        public void Save(object commandParameter)
        {
            var editStudentWindow = commandParameter as EditStudentWindow;

            if (editStudentWindow == null) return;

            editStudentWindow.DialogResult = true;
        }

        #endregion ISaveCommandService
    }
}
