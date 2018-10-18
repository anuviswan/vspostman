using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using VsPostman.HttpRequest;

namespace VsPostman.Convertor
{
    public class ResponseToBooleanConvertor :MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return false;
            var currentValue = value as ResponseObject;
            return currentValue.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new ResponseToBooleanConvertor(); 
        }
    }
}
