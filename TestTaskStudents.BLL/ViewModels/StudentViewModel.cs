using System;

using TestTaskStudents.BLL.Infrastructure;
using TestTaskStudents.DAL.Models;
using TestTaskStudents.DAL.Infrastructure;

namespace TestTaskStudents.BLL.ViewModels
{
    public class StudentViewModel : ChangeNotifier, ICloneable
    {
        private Student student;

        public int Id
        {
            get
            {
                return student.Id;
            }
            set
            {
                student.Id = value;

                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get
            {
                return student.FirstName;
            }
            set
            {
                student.FirstName = value;

                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get
            {
                return student.LastName;
            }
            set
            {
                student.LastName = value;

                OnPropertyChanged();
            }
        }

        public int Age
        {
            get
            {
                return student.Age;
            }
            set
            {
                student.Age = value;

                OnPropertyChanged();
            }
        }

        public Gender Gender
        {
            get
            {
                return student.Gender;
            }
            set
            {
                student.Gender = value;

                OnPropertyChanged();
            }
        }

        public StudentViewModel()
        {
            student = new Student();
        }

        #region ICloneable

        public object Clone()
        {
            return new StudentViewModel
            {
                student = new Student
                {
                    Id = this.Id,
                    FirstName = this.FirstName,
                    LastName = this.LastName,
                    Age = this.Age,
                    Gender = this.Gender
                }
            };
        }

        #endregion ICloneable
    }
}
