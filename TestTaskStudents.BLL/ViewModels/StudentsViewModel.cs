using System;
using System.Collections;
using System.Collections.Generic;
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
        private IDeleteCommandService deleteCommandService;

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
        private RelayCommand deleteCommand;

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

        public RelayCommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand(DeleteStudents, obj => selectedStudent != null);
                }

                return deleteCommand;
            }
        }

        #endregion Commands

        public StudentsViewModel(IStudentService studentService, IDeleteCommandService deleteParameterService)
        {
            this.studentService = studentService;
            this.deleteCommandService = deleteParameterService;

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

            var lastId = (Students.Count > 0) ? (from s in Students
                                                 select s.Id).Max() 
                                                 : 1;
            var newId = lastId + 1;

            student.Id = newId;

            Students.Add(student);

            SelectedStudent = student;
        }

        private void DeleteStudents(object parameter)
        {
            if (studentService.Delete())
            {
                var studentsForDelete = deleteCommandService.GetStudents(parameter);

                foreach (var student in studentsForDelete)
                {
                    Students.Remove((StudentViewModel)student);
                }
            }
        }
    }
}
