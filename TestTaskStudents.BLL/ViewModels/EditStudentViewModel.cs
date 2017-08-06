using System;
using System.Windows.Input;

using TestTaskStudents.BLL.Interfaces;
using TestTaskStudents.BLL.Commands;
using TestTaskStudents.BLL.DTO;

namespace TestTaskStudents.BLL.ViewModels
{
    public class EditStudentViewModel: IEditStudentViewModel
    {
        private ISaveCommandService saveCommandService;

        public StudentDTO Student { get; set; }
        
        public EditStudentViewModel(ISaveCommandService saveCommandService)
        {
            this.saveCommandService = saveCommandService;
        }

        #region Commands

        private RelayCommand saveCommand;

        public ICommand SaveCommand
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
