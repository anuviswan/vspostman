using System.Collections.Generic;
using System.Windows.Controls;
using VsPostman.HttpRequest;

namespace VsPostman.Controls
{
    /// <summary>
    /// Interaction logic for ResponseHeaders.xaml
    /// </summary>
    public partial class ResponseHeader : UserControl, IResponse
    {
        public ResponseHeader() => InitializeComponent();

        public void Update(ResponseObject response)
        {
            HeaderList.Clear();

            foreach (string key in response.Headers.Keys)
            {
                HeaderList.Add(key, response.Headers.Get(key));
            }

            dgHeaders.ItemsSource = HeaderList;
        }

        public IDictionary<string, string> HeaderList { get; set; } = new Dictionary<string, string>();
    }
}
