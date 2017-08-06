using System;
using System.Collections;
using System.Collections.Generic;

using TestTaskStudents.BLL.Interfaces;
using TestTaskStudents.BLL.DTO;

namespace TestTaskStudents.APP.Services
{
    public class DeleteCommandService : IDeleteCommandService
    {
        #region IDeleteCommandService

        public IEnumerable<StudentDTO> GetStudents(object deleteParameter)
        {
            int selectedStudentsCount = ((IList)deleteParameter).Count;
            List<StudentDTO> selectedStudents = new List<StudentDTO>(selectedStudentsCount);

            foreach (var item in (IEnumerable)deleteParameter)
            {
                selectedStudents.Add((StudentDTO)item);
            }

            return selectedStudents;
        }

        #endregion IDeleteCommandService
    }
}
