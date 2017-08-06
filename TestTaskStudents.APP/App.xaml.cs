using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using Ninject;

using TestTaskStudents.APP.Infrastructure;
using TestTaskStudents.BLL.Infrastructure;

namespace TestTaskStudents.APP
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static string xmlFilePath = "Data/Students.xml";

        public IKernel Kernel { get; private set; } 

        public App()
        {
            Kernel = new StandardKernel(new BllServiceModule(xmlFilePath), new AppServiceModule());
        }
    }
}
