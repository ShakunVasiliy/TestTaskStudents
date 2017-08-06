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

using TestTaskStudents.BLL.Interfaces;
using TestTaskStudents.BLL.DTO;
using TestTaskStudents.APP.Services;

using Ninject;

namespace TestTaskStudents.APP.Views
{
    /// <summary>
    /// Логика взаимодействия для EditStudentWindow.xaml
    /// </summary>
    public partial class EditStudentWindow : Window
    {
        public EditStudentWindow()
            : this(new StudentDTO())
        { }

        public EditStudentWindow(StudentDTO student)
        {
            InitializeComponent();
            InitializeDataContext(student);            
        }

        private void InitializeDataContext(StudentDTO student)
        {
            IEditStudentViewModel editStudentViewModel = ((App)App.Current).Kernel.Get<IEditStudentViewModel>();
            editStudentViewModel.Student = student;

            this.DataContext = editStudentViewModel;
        }
    }
}
