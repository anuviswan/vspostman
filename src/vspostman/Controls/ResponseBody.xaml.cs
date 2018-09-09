using System.Windows.Controls;
using VsPostman.HttpRequest;

namespace VsPostman.Controls
{
    /// <summary>
    /// Interaction logic for ResponseBody.xaml
    /// </summary>
    public partial class ResponseBody : UserControl, IResponse
    {
        public ResponseBody() => InitializeComponent();
        public void Update(ResponseObject response) => responsePretty.Text = response.ResponseString;
        
    }
}
