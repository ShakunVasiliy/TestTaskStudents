using System;

using Ninject.Modules;

using TestTaskStudents.BLL.Interfaces;
using TestTaskStudents.BLL.ViewModels;
using TestTaskStudents.APP.Services;

namespace TestTaskStudents.APP.Infrastructure
{
    public class AppServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStudentService>().To<StudentService>();
            Bind<IDeleteCommandService>().To<DeleteCommandService>();
            Bind<ISaveCommandService>().To<SaveCommandService>();
            Bind<IStudentsViewModel>().To<StudentsViewModel>();
            Bind<IEditStudentViewModel>().To<EditStudentViewModel>();
        }
    }
}
