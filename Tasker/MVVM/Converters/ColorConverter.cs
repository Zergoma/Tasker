using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Tasker.MVVM.Converters
{
    public class ColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if(value is string str)
            {
                return Color.FromArgb(str);
            }
            return null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if(value is Color color)
            {
                return color.ToHex();
            }
            return null;
        }
    }
}
