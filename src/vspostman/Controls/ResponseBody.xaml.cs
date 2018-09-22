using System.Windows.Controls;
using VsPostman.HttpRequest;

namespace VsPostman.Controls
{
    /// <summary>
    /// Interaction logic for ResponseBody.xaml
    /// </summary>
    public partial class ResponseBody : UserControl
    {
        public ResponseBody()
        {
            InitializeComponent();
            DataContext = new ResponseBodyViewModel();
        }
        
    }
}
