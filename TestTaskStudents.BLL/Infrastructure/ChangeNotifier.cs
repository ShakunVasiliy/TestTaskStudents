using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestTaskStudents.BLL.Infrastructure
{
    public abstract class ChangeNotifier: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
