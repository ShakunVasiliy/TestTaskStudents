﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

using TestTaskStudents.APP.Services;
using TestTaskStudents.BLL.Interfaces;

using Ninject;

namespace TestTaskStudents.APP.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeDataContext();
        }

        private void InitializeDataContext()
        {
            IStudentsViewModel studentsViewModule = ((App)App.Current).Kernel.Get<IStudentsViewModel>();

            this.DataContext = studentsViewModule;
        }
    }
}
