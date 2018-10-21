using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VsPostman.HttpRequest
{
    public class ClientServiceUsingRestSharp : IRequest
    {
        private RestRequest _restRequest;
        private IRestClient _restClient;
        private IDictionary<string, dynamic> _parameterDictionary;

        public ClientServiceUsingRestSharp(IRestClient client=null)
        {
            _restClient = client ?? new RestClient();
            _restRequest = new RestRequest();
            _parameterDictionary = new Dictionary<string, dynamic>();
        }

        public string ParameterString => throw new NotImplementedException();

        public void AddParameter(string parameterName, dynamic value)
        {
            if (!_parameterDictionary.ContainsKey(parameterName))
                _parameterDictionary.Add(parameterName, value);
        }

        public void ClearParameters()
        {
            _parameterDictionary.Clear();
        }


        public Task<ResponseObject> Get(string url)
        {
            if (string.IsNullOrWhiteSpace(url) || _parameterDictionary.Values.Contains(null)) throw new ArgumentNullException();

            _restClient.BaseUrl = new Uri(url);
            _restRequest.Method = Method.GET;
            var _returnValue = new ResponseObject();
            if(_parameterDictionary?.Count==0)
                _restRequest.Parameters.AddRange(_parameterDictionary?.Select(x => new Parameter() {Name = x.Key, Value = x.Value }));
            _restClient.ExecuteAsync(_restRequest, response =>
            {
                _returnValue.ContendType = response.ContentType;
                _returnValue.ResponseString = response.Content;
                _returnValue.StatusCode = response.StatusCode;
                _returnValue.StatusDescription = response.StatusDescription;
                if(response.Headers!=null)
                    _returnValue.Headers = response.Headers.ToDictionary(x => x.Name, y => y.Value as string);
                _returnValue.ResponseTime = new TimeSpan(1000);
            });
            return Task.FromResult<ResponseObject>(_returnValue);
        }
    }
}
