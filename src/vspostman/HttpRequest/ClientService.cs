using LazyCache;
using LazyCache.Providers;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace VsPostman.HttpRequest
{
    public class ClientService : IRequest
    {
        private HttpClient _httpClient;
        private static IAppCache _cache;
        private IDictionary<string, dynamic> _parameterDictionary;

        public string Url { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ClientService(IMemoryCache cache)
        {
            _cache = new CachingService(new MemoryCacheProvider(cache));
            _httpClient = new HttpClient();
            _parameterDictionary = new Dictionary<string, dynamic>();
        }


        public void Get()
        {
            
        }

        public void AddParameter(string parameterName, dynamic value)
        {
            if (!_parameterDictionary.ContainsKey(parameterName))
                _parameterDictionary.Add(parameterName, value);
        }
    }
}

