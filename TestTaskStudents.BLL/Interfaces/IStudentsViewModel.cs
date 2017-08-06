using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

using TestTaskStudents.BLL.DTO;

namespace TestTaskStudents.BLL.Interfaces
{
    public interface IStudentsViewModel
    {
        StudentDTO SelectedStudent { get; set; }
        ObservableCollection<StudentDTO> Students { get; set; }
        ICommand AddCommand { get; }
        ICommand EditCommand { get; }
        ICommand DeleteCommand { get; }
        ICommand SaveCommand { get; }
    }
}
