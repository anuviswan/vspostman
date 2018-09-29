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

namespace VsPostman.Controls.Response
{
    /// <summary>
    /// Interaction logic for ResponseBody.xaml
    /// </summary>
    public partial class ResponseBody : ResponseBase,IHasResponse
    {
        public ResponseBody()
        {
            InitializeComponent();
        }

        public void Update(ResponseObject responseObject)
        {
            txtResponseBody.Text = responseObject.ResponseString;
        }
    }
}
