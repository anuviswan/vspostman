namespace VsPostman
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using VsPostman.HttpRequest;

    /// <summary>
    /// Interaction logic for PostmanToolWindowControl.
    /// </summary>
    public partial class PostmanToolWindowControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostmanToolWindowControl"/> class.
        /// </summary>
        public PostmanToolWindowControl()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private async void SendRequest(object sender, RoutedEventArgs e)
        {
            var url = requestedUrl.Text;
            var worker = new Worker();
            switch ((eRequestType)Enum.Parse(typeof(eRequestType), httpType.SelectedValue.ToString(), true))
            {
                case eRequestType.POST:
                    break;
                case eRequestType.GET:
                    var result = await worker.SendGetRequest(url, new Dictionary<string, string>());
                    UpdateUIWithResult(result);
                    break;
                case eRequestType.PUT:
                    break;
                case eRequestType.DELETE:
                    break;
                default:
                    break;
            }

        }

        public void UpdateUIWithResult(ResponseObject response)
        {
            statusText.Content = $"Status :{response.StatusCode.ToString()},Time:{response.ResponseTime.TotalMilliseconds}";
        }
    }
}