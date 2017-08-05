using System;
using System.Collections.ObjectModel;

using TestTaskStudents.BLL.Commands;
using TestTaskStudents.BLL.Interfaces;
using TestTaskStudents.BLL.Infrastructure;
using TestTaskStudents.DAL.Infrastructure;

namespace TestTaskStudents.BLL.ViewModels
{
    public class StudentsViewModel : ChangeNotifier
    {
        private StudentViewModel selectedStudent;

        private IStudentService studentService;

        public ObservableCollection<StudentViewModel> Students { get; set; }

        public StudentViewModel SelectedStudent
        {
            get
            {
                return selectedStudent;
            }
            set
            {
                selectedStudent = value;

                OnPropertyChanged();
            }
        }

        #region Commands

        private RelayCommand editCommand;
        private RelayCommand addCommand;
        private RelayCommand removeCommand;

        public RelayCommand EditCommand
        {
            get
            {
                if (editCommand == null)
                {
                    editCommand = new RelayCommand(EditSelectedStudent);
                }

                return editCommand;
            }
        }

        #endregion Commands

        public StudentsViewModel(IStudentService studentService)
        {
            this.studentService = studentService;

            Students = new ObservableCollection<StudentViewModel>()
            {
                new StudentViewModel
                {
                    Id = 1,
                    FirstName = "Vasya",
                    LastName = "Shakun",
                    Age = 24,
                    Gender = Gender.Man
                },
                new StudentViewModel
                {
                    Id = 1,
                    FirstName = "Leha",
                    LastName = "Kozarez",
                    Age = 24,
                    Gender = Gender.Man
                },
            };
        }

        private void EditSelectedStudent(object parameter)
        {
            if (SelectedStudent == null) return;
            
            var selectedStudentClone = (StudentViewModel)SelectedStudent.Clone();
            var editResult = studentService.Edit(selectedStudentClone);

            if (editResult)
            {
                SelectedStudent.FirstName = selectedStudentClone.FirstName;
                SelectedStudent.LastName = selectedStudentClone.LastName;
                SelectedStudent.Age = selectedStudentClone.Age;
                SelectedStudent.Gender = selectedStudentClone.Gender;
            }
        }
    }
}
