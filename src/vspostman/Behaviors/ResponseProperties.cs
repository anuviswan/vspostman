using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VsPostman.Controls.Response;
using VsPostman.HttpRequest;

namespace VsPostman.Behaviors
{
    public class ResponseProperties:DependencyObject
    {

        public static readonly DependencyProperty ResponseObjectProperty = DependencyProperty.RegisterAttached(
          "Response",
          typeof(ResponseObject),
          typeof(ResponseProperties),
          new PropertyMetadata(default(ResponseObject), ResponseChanged) );

        private static void ResponseChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as UIElement;

            if(control is IHasResponse)
            {
                ((IHasResponse)control).Update(e.NewValue as ResponseObject);
            }
        }

        public static void SetResponse(UIElement element, ResponseObject value)
        {
            element.SetValue(ResponseObjectProperty, value);
        }
        public static ResponseObject GetResponse(UIElement element)
        {
            return (ResponseObject)element.GetValue(ResponseObjectProperty);
        }


    }
}
