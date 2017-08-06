using System;
using System.Globalization;
using System.Windows.Data;

namespace TestTaskStudents.BLL.Infrastructure
{
    public class AgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int age = (int)value;
            string ageString = age.ToString();

            int remainder = age % 10;

            if ((10 <= age) && (age < 20))
            {
                ageString += " лет";
            }
            else if (remainder == 1)
            {
                ageString += " год";
            } 
            else if ((0 < remainder) && (remainder < 5))
            {
                ageString += " годa";
            }
            else
            {
                ageString += " лет";
            }

            return ageString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
