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
            return ((Gender)value).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Gender gender;
            var parseResult = Enum.TryParse(value.ToString(), true, out gender);

            return parseResult ? gender : Gender.Man;
        }
    }
}
