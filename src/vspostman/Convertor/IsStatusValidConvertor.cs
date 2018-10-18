﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace VsPostman.Convertor
{
    public class IsStatusValidConvertor :MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var returnValue = false;
            if (string.IsNullOrEmpty(value as string)) return false;
            if(value is string currentValue)
            {
                if (currentValue.Trim().Equals("200 OK"))
                    return true;
            }
            return returnValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new IsStatusValidConvertor(); 
        }
    }
}
