using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
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
            _restRequest.Method = Method.GET;
            _restRequest.Resource = url;
            _restRequest.Parameters.AddRange(_parameterDictionary.Select(x => new Parameter() {Name = x.Key, Value = x.Value }));
            var response = _restClient.Execute(_restRequest);
            return default;
        }
    }
}
