using LazyCache;
using LazyCache.Providers;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace VsPostman.HttpRequest
{
    public class ClientService : IRequest
    {
        private HttpClient _httpClient;
        private IAppCache _cache;
        private IDictionary<string, dynamic> _parameterDictionary;

        public string Url { get; set; }

        public ClientService(IMemoryCache cache)
        {
            _cache = new CachingService(new MemoryCacheProvider(cache));
            _httpClient = new HttpClient();
            _parameterDictionary = new Dictionary<string, dynamic>();
        }


        public void Get()
        {
            _httpClient.BaseAddress = new Uri(Url);
            _httpClient.GetAsync($"?{Parameters()}");
            
        }

        public void AddParameter(string parameterName, dynamic value)
        {
            if (!_parameterDictionary.ContainsKey(parameterName))
                _parameterDictionary.Add(parameterName, value);
        }

        private string Parameters() => string.Join("&", _parameterDictionary.Select(pair => $"{pair.Key}={pair.Value}"));

        public void ClearParameters() => _parameterDictionary.Clear();
    }
}

