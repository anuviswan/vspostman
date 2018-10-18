using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VsPostman.HttpRequest;

namespace VsPostman.Controls.Response
{
    public class ResponseBase:UserControl
    {
        public static readonly DependencyProperty ResponseProperty = DependencyProperty.Register(
         "Response",
         typeof(ResponseObject),
         typeof(ResponseBase),
         new PropertyMetadata(null));

     

        public ResponseObject Response
        {
            get { return (ResponseObject)GetValue(ResponseProperty); }
            set { SetValue(ResponseProperty, value); }
        }

    }
}
