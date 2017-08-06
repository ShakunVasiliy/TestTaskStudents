using System;

using Ninject.Modules;

using TestTaskStudents.DAL.Interfaces;
using TestTaskStudents.DAL.Repositories;

namespace TestTaskStudents.BLL.Infrastructure
{
    public class BllServiceModule: NinjectModule
    {
        private string xmlFilePath;

        public BllServiceModule(string xmlFilePath)
        {
            this.xmlFilePath = xmlFilePath;
        }

        public override void Load()
        {
            Bind<IStudentRepository>().To<StudentRepository>().WithConstructorArgument(xmlFilePath);
        }
    }
}
