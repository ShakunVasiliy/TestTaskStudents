using System;

using TestTaskStudents.BLL.Interfaces;
using TestTaskStudents.BLL.Commands;

namespace TestTaskStudents.BLL.ViewModels
{
    public class EditStudentViewModel
    {
        private ISaveCommandService saveCommandService;

        public StudentViewModel Student { get; private set; }
        
        public EditStudentViewModel(StudentViewModel student, ISaveCommandService saveCommandService)
        {
            this.Student = student;
            this.saveCommandService = saveCommandService;
        }

        #region Commands

        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new RelayCommand(Save, obj => string.IsNullOrEmpty(Student.Error));
                }

                return saveCommand;
            }
        }

        #endregion Commands

        private void Save(object parameter)
        {
            saveCommandService.Save(parameter);
        }
    }
}
