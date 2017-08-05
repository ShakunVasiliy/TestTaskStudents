using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using TestTaskStudents.BLL.ViewModels;
using TestTaskStudents.BLL.Infrastructure;

namespace TestTaskStudents.APP.Views
{
    /// <summary>
    /// Логика взаимодействия для EditStudentWindow.xaml
    /// </summary>
    public partial class EditStudentWindow : Window
    {
        public EditStudentWindow()
        {
            InitializeComponent();

            this.DataContext = new EditStudentViewModule();
            this.Resources.Add("GenderConverter", new GenderConverter());
        }
    }
}
