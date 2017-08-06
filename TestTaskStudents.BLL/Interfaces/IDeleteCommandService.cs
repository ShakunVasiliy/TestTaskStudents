using System;
using System.Collections.Generic;

using TestTaskStudents.BLL.ViewModels;

namespace TestTaskStudents.BLL.Interfaces
{
    public interface IDeleteCommandService
    {
        IEnumerable<StudentViewModel> GetStudents(object deleteParameter);
    }
}