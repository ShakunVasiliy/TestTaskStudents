using System;
using System.Collections.Generic;

using TestTaskStudents.BLL.ViewModels;

namespace TestTaskStudents.BLL.Interfaces
{
    public interface IDeleteParameterService
    {
        IEnumerable<StudentViewModel> GetStudents(object deleteParameter);
    }
}