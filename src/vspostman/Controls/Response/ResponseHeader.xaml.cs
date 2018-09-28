using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

namespace VsPostman.Controls.Response
{
    /// <summary>
    /// Interaction logic for ResponseHeader.xaml
    /// </summary>
    public partial class ResponseHeader : ResponseBase, IHasResponse
    {
        public ResponseHeader()
        {
            InitializeComponent();
        }

        public void Update(ResponseObject responseObject)
        {
            var headerDictionary = responseObject.Headers.Cast<string>().ToDictionary(x=>x,v=>responseObject.Headers[v]);
            
            dgHeaders.ItemsSource = headerDictionary;
        }

        
    }
}
