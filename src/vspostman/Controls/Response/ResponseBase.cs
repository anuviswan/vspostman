using System;
using System.Collections.Generic;
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
        public ResponseObject Response
        {
            get { return (ResponseObject)GetValue(ResponseProperty); }
            set { SetValue(ResponseProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ResponseProperty =
            DependencyProperty.Register("Response", typeof(ResponseObject), typeof(ResponseBase), new PropertyMetadata(default(ResponseObject)));
    }
}
