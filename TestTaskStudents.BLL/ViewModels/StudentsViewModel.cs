using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

using TestTaskStudents.BLL.Commands;
using TestTaskStudents.BLL.Interfaces;
using TestTaskStudents.BLL.Infrastructure;
using TestTaskStudents.BLL.Utils;
using TestTaskStudents.BLL.DTO;
using TestTaskStudents.DAL.Infrastructure;
using TestTaskStudents.DAL.Interfaces;
using TestTaskStudents.DAL.Repositories;
using TestTaskStudents.DAL.Models;

namespace TestTaskStudents.BLL.ViewModels
{
    public class StudentsViewModel : ChangeNotifier, IStudentsViewModel
    {
        private StudentDTO selectedStudent;

        private IStudentService studentService;
        private IDeleteCommandService deleteCommandService;

        private IStudentRepository studentRepository;

        public ObservableCollection<StudentDTO> Students { get; set; }

        public StudentDTO SelectedStudent
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

        public ICommand AddCommand
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

        public ICommand EditCommand
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

        public ICommand DeleteCommand
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

        public ICommand SaveCommand
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

        public StudentsViewModel(IStudentService studentService, IDeleteCommandService deleteParameterService, IStudentRepository studentRepository)
        {
            this.studentService = studentService;
            this.deleteCommandService = deleteParameterService;
            this.studentRepository = studentRepository;
            
            Students = MappingUtil.MapToObservebleCollection<Student, StudentDTO>(studentRepository.GetAll());
        }

        private void EditSelectedStudent(object parameter)
        {
            if (SelectedStudent == null) return;
            
            var selectedStudentClone = (StudentDTO)SelectedStudent.Clone();
            var editResult = studentService.Edit(selectedStudentClone);

            if (editResult)
            {
                SelectedStudent.FirstName = selectedStudentClone.FirstName;
                SelectedStudent.LastName = selectedStudentClone.LastName;
                SelectedStudent.Age = selectedStudentClone.Age;
                SelectedStudent.Gender = selectedStudentClone.Gender;
                
                var student = MappingUtil.MapToInstance<StudentDTO, Student>(selectedStudent);
                studentRepository.Update(student);
            }
        }

        private void AddStudent(object parameter)
        {
            var studentViewModel = studentService.Create();

            if (studentViewModel == null) return;
            
            var student = MappingUtil.MapToInstance<StudentDTO, Student>(studentViewModel);

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
                    Students.Remove((StudentDTO)student);

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
