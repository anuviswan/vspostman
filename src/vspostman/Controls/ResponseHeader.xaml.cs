using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VsPostman.HttpRequest;

namespace VsPostman.Controls
{
    /// <summary>
    /// Interaction logic for ResponseHeaders.xaml
    /// </summary>
    public partial class ResponseHeader : UserControl, IResponse
    {
        public ResponseHeader()
        {
            InitializeComponent();
        }

        public void Update(ResponseObject response)
        {
            var headerString = new StringBuilder();
            foreach (string key in response.Headers.Keys)
            {
                headerString.AppendLine($"{key}-> {response.Headers.Get(key)}");
            }

            responseHeaders.Text = headerString.ToString();
        }
    }
}
