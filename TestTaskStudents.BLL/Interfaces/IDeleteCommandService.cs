using System;
using System.Collections.Generic;

using TestTaskStudents.BLL.DTO;

namespace TestTaskStudents.BLL.Interfaces
{
    public interface IDeleteCommandService
    {
        IEnumerable<StudentDTO> GetStudents(object deleteParameter);
    }
}