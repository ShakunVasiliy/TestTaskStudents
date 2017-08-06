using System;
using System.Globalization;
using System.Windows.Data;

using TestTaskStudents.DAL.Infrastructure;

namespace TestTaskStudents.BLL.Infrastructure
{
    public class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((Gender)value)
            {
                case Gender.Man:
                    return "Мужчина";
                case Gender.Woman:
                    return "Женщина";
                default:
                    return "";
            }            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value.ToString())
            {
                case "Мужчина":
                    return Gender.Man;
                case "Женщина":
                    return Gender.Woman;
                default:
                    return Gender.Man;
            }
        }
    }
}
