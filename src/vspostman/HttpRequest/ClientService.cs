using LazyCache;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace VsPostman.HttpRequest
{
    public class ClientService : IRequest
    {
        private IAppCache _cache;
        private IDictionary<string, dynamic> _parameterDictionary;
        private IHttpWebRequestFactory _webRequest;

        public string ParameterString => string.Join("&", _parameterDictionary.Select(pair => $"{pair.Key}={pair.Value}"));

        public ClientService(IHttpWebRequestFactory webRequest )
        {
            _parameterDictionary = new Dictionary<string, dynamic>();
            _webRequest = webRequest;
        }

        public ClientService() => _parameterDictionary = new Dictionary<string, dynamic>();

        public async Task<ResponseObject> Get(string url)
        {
            if (string.IsNullOrWhiteSpace(url) || _parameterDictionary.Values.Contains(null)) throw new ArgumentNullException();

            var request =_parameterDictionary.Count > 0 ? _webRequest.Create($"{url}?{ParameterString}") : _webRequest.Create(url);

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var watch = Stopwatch.StartNew();
                var returnValue = await reader.ReadToEndAsync();
                return new ResponseObject
                {
                    ContendType = response.ContentType,
                    Length = response.ContentLength,
                    ResponseString = returnValue,
                    ResponseTime = watch.Elapsed,
                    StatusCode = response.StatusCode,

                };
            }
        }

        public void AddParameter(string parameterName, dynamic value)
        {
            if (!_parameterDictionary.ContainsKey(parameterName))
                _parameterDictionary.Add(parameterName, value);
        }
        public void ClearParameters() => _parameterDictionary.Clear();
    }
}

