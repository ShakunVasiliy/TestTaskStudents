using System;
using System.Collections.ObjectModel;
using System.Linq;

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

        private RelayCommand addCommand;
        private RelayCommand editCommand;
        private RelayCommand removeCommand;

        public RelayCommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(AddStudent);
                }

                return addCommand;
            }
        }

        public RelayCommand EditCommand
        {
            get
            {
                if (editCommand == null)
                {
                    editCommand = new RelayCommand(EditSelectedStudent, obj => SelectedStudent != null);
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

        private void AddStudent(object parameter)
        {
            var student = studentService.Create();

            if (student == null) return;

            var lastId = (from s in Students
                          select s.Id).Max();
            var newId = lastId + 1;

            student.Id = newId;

            Students.Add(student);
        }
    }
}
