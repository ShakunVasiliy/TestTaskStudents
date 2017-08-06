using System;
using System.ComponentModel;

using TestTaskStudents.BLL.Infrastructure;
using TestTaskStudents.DAL.Models;
using TestTaskStudents.DAL.Infrastructure;

namespace TestTaskStudents.BLL.ViewModels
{
    public class StudentViewModel : ChangeNotifier, ICloneable, IDataErrorInfo
    {
        private static int minAgeValue = 16;
        private static int maxAgeValue = 100;

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

        #region IDataErrorInfo

        public string Error
        {
            get
            {
                var error = this["Id"];
                error += this["FirstName"];
                error += this["LastName"];
                error += this["Age"];
                error += this["Gender"];

                return error;
            }
        }

        public string this[string fieldName]
        {
            get
            {
                string error = string.Empty;

                switch (fieldName)
                {
                    case "FirstName":
                        error = string.IsNullOrEmpty(FirstName) ? "Имя должно быть заполнено." : string.Empty;
                        break;
                    case "LastName":
                        error = string.IsNullOrEmpty(LastName) ? "Фамилия должна быть заполнена." : string.Empty;
                        break;
                    case "Age":
                        if ((Age < minAgeValue) || (maxAgeValue < Age))
                        {
                            error = $"Возраст должен быть не меньше {minAgeValue} и не больше {maxAgeValue}.";
                        }
                        break;
                }

                return error;
            }
        }


        #endregion IDataErrorInfo
    }
}
