using System;
using System.Collections;
using System.Collections.Generic;

using TestTaskStudents.BLL.Interfaces;
using TestTaskStudents.BLL.ViewModels;

namespace TestTaskStudents.APP.Services
{
    public class DeleteCommandService : IDeleteCommandService
    {
        #region IDeleteCommandService

        public IEnumerable<StudentViewModel> GetStudents(object deleteParameter)
        {
            int selectedStudentsCount = ((IList)deleteParameter).Count;
            List<StudentViewModel> selectedStudents = new List<StudentViewModel>(selectedStudentsCount);

            foreach (var item in (IEnumerable)deleteParameter)
            {
                selectedStudents.Add((StudentViewModel)item);
            }

            return selectedStudents;
        }

        #endregion IDeleteCommandService
    }
}
