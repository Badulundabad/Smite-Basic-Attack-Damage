using System.ComponentModel;
using System.Globalization;
using System;
using System.Windows.Data;

namespace SmiteBasicAttackDamage
{
    public class FractionalValueToIntegerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)((double)value * 100);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
