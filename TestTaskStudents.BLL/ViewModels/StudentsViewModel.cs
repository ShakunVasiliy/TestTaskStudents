using System;
using System.Collections.ObjectModel;

using TestTaskStudents.BLL.Infrastructure;
using TestTaskStudents.DAL.Infrastructure;

namespace TestTaskStudents.BLL.ViewModels
{
    public class StudentsViewModel
    {
        public ObservableCollection<StudentViewModel> Students { get; set; }

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
