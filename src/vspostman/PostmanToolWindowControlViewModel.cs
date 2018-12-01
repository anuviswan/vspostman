using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VsPostman.Commands;
using VsPostman.Dto;
using VsPostman.HttpRequest;

namespace VsPostman
{
    public class PostmanToolWindowControlViewModel : PropertyChangeBase
    {
        public PostmanToolWindowControlViewModel ()
	    {
            SendRequestCommand = new SimpleCommandAsync(SendRequestAsync);
            AddUrlParamCommand = new SimpleCommand(AddUrlParam);
	    }

        private void AddUrlParam()
        {
            UrlParamCollection.Add(new UrlParamDto { Key = string.Empty, Description = string.Empty, Value = string.Empty });
        }

        public eRequestType RequestType { get; set; } = eRequestType.GET;
        
        public string Url { get; set; } 
        public ICommand SendRequestCommand{get;set;}
        public ICommand AddUrlParamCommand { get; set; }

        public async Task SendRequestAsync()
        {
            var worker = new Worker();
            switch (RequestType)
            {
                case eRequestType.POST:
                    break;
                case eRequestType.GET:
                    var result = await worker.SendGetRequest(Url, UrlParamCollection.ToDictionary(x => x.Key, y => y.Value));
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

        public BindingList<UrlParamDto> UrlParamCollection { get; set; } = new BindingList<UrlParamDto>(new[] { new UrlParamDto { Key = string.Empty, Description = string.Empty, Value = string.Empty } });


}
}
