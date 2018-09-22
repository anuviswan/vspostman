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

namespace VsPostman.Controls.Response
{
    /// <summary>
    /// Interaction logic for ResponseHeader.xaml
    /// </summary>
    public partial class ResponseHeader : ResponseBase
    {
        public ResponseHeader()
        {
            InitializeComponent();
            DataContext = new ResponseHeaderViewModel();
        }
    }
}
