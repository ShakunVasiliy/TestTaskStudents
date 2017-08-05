using System;
using System.Collections.ObjectModel;

using TestTaskStudents.BLL.Infrastructure;
using TestTaskStudents.DAL.Infrastructure;

namespace TestTaskStudents.BLL.ViewModels
{
    public class StudentsViewModel : ChangeNotifier
    {
        private StudentViewModel selectedStudent;

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

        public StudentsViewModel()
        {
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
    }
}
