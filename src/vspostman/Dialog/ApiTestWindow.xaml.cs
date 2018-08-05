using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace VsPostman.Dialog
{
    /// <summary>
    /// Interaction logic for ApiTestWindow.xaml
    /// </summary>
    public partial class ApiTestWindow : BaseDialogWindow
    {
        public ApiTestWindow()
        {
            InitializeComponent();
        }

        private async void SendRequest(object sender, RoutedEventArgs e)
        {
            switch ((eRequestType)Enum.Parse(typeof(eRequestType), httpType.SelectedValue.ToString(), true))
            {
                case eRequestType.POST:
                    break;
                case eRequestType.GET:
                    var client = new ClientService(new HttpWebRequestFactory())
                    {
                        Url = requestedUrl.Text
                        
                    };
                    var output = await client.Get();
                    break;
                case eRequestType.PUT:
                    break;
                case eRequestType.DELETE:
                    break;
                default:
                    break;
            }
        }
    }
}
