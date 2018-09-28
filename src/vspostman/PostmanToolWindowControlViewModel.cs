using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VsPostman.Commands;
using VsPostman.HttpRequest;

namespace VsPostman
{
    public class PostmanToolWindowControlViewModel : PropertyChangeBase
    {
        public PostmanToolWindowControlViewModel ()
	    {
            SendRequestCommand = new SimpleCommandAsync(SendRequestAsync);
	    }

        public eRequestType RequestType { get; set; }
        
        public string Url { get; set; } = "Enter your Url here";
        public ICommand SendRequestCommand{get;set;}

        public async Task SendRequestAsync()
        {
            var worker = new Worker();
            switch (RequestType)
            {
                case eRequestType.POST:
                    break;
                case eRequestType.GET:
                    var result = await worker.SendGetRequest(Url, new Dictionary<string, string>());
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

        private void UpdateUIWithResult(ResponseObject result)
        {
            Result = result;
            OnPropertyChanged(nameof(Result));
            Status = $@"Status: {(int)result.StatusCode} {result.StatusCode.ToString()}, Time: {result.ResponseTime.TotalMilliseconds:0.##} ms Size: {result.Length} B";
            OnPropertyChanged(nameof(Status));
        }

        public ResponseObject Result
        {
            get;set;
        }

        public string Status { get; set; }

    }
}
