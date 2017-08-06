using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using TestTaskStudents.BLL.Commands;
using TestTaskStudents.BLL.Interfaces;
using TestTaskStudents.BLL.Infrastructure;
using TestTaskStudents.BLL.Utils;
using TestTaskStudents.DAL.Infrastructure;
using TestTaskStudents.DAL.Interfaces;
using TestTaskStudents.DAL.Repositories;
using TestTaskStudents.DAL.Models;

namespace TestTaskStudents.BLL.ViewModels
{
    public class StudentsViewModel : ChangeNotifier
    {
        private StudentViewModel selectedStudent;

        private IStudentService studentService;
        private IDeleteCommandService deleteCommandService;

        private IStudentRepository studentRepository;

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
        private RelayCommand saveCommand;

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

        public RelayCommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new RelayCommand(SaveStudents);
                }

                return saveCommand;
            }
        }


        #endregion Commands

        public StudentsViewModel(IStudentService studentService, IDeleteCommandService deleteParameterService)
        {
            this.studentService = studentService;
            this.deleteCommandService = deleteParameterService;
            this.studentRepository = new StudentRepository("Data/Students.xml");
            
            Students = MappingUtil.MapToObservebleCollection<Student, StudentViewModel>(studentRepository.GetAll());
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
                
                var student = MappingUtil.MapToInstance<StudentViewModel, Student>(selectedStudent);
                studentRepository.Update(student);
            }
        }

        private void AddStudent(object parameter)
        {
            var studentViewModel = studentService.Create();

            if (studentViewModel == null) return;
            
            var student = MappingUtil.MapToInstance<StudentViewModel, Student>(studentViewModel);

            studentRepository.Add(student);
            studentViewModel.Id = student.Id;
            Students.Add(studentViewModel);

            SelectedStudent = studentViewModel;
        }

        private void DeleteStudents(object parameter)
        {
            if (studentService.Delete())
            {
                var studentsForDelete = deleteCommandService.GetStudents(parameter);

                foreach (var student in studentsForDelete)
                {
                    Students.Remove((StudentViewModel)student);

                    studentRepository.Delete(student.Id);
                }
            }
        }

        private void SaveStudents(object parameter)
        {
            studentRepository.Save();
        }
    }
}
