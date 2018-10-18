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
    /// Interaction logic for ResponseStatus.xaml
    /// </summary>
    public partial class ResponseStatus : ResponseBase//, IHasResponse
    {
        public ResponseStatus()
        {
            InitializeComponent();

        }

        public bool IsVisibile => Response != null;

        //public void Update(ResponseObject responseObject)
        //{
        //    statusPanel.Visibility = Visibility.Visible;
        //    StatusResult.Text = $"{(int)responseObject.StatusCode} {responseObject.StatusCode.ToString()}";
        //    Time.Text = $"{responseObject.ResponseTime.TotalMilliseconds:0.##} ms";
        //    Size.Text = $"{responseObject.Length} B";
        //}
    }

  
}
