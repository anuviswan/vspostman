using LazyCache;
using LazyCache.Providers;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace VsPostman.HttpRequest
{
    public class ClientService : IRequest
    {
        private HttpClient _httpClient;
        private IAppCache _cache;
        private IDictionary<string, dynamic> _parameterDictionary;

        public string Url { get; set; }

        public string ParameterString => string.Join("&", _parameterDictionary.Select(pair => $"{pair.Key}={pair.Value}"));

        public ClientService(IMemoryCache cache)
        {
            _cache = new CachingService(new MemoryCacheProvider(cache));
            _httpClient = new HttpClient();
            _parameterDictionary = new Dictionary<string, dynamic>();
        }

        public ClientService()
        {
            _httpClient = new HttpClient();
            _parameterDictionary = new Dictionary<string, dynamic>();
        }


        public async Task<TResponse> Get<TResponse>()
        {
            _httpClient.BaseAddress = new Uri(Url);
            var response = await _httpClient.GetAsync($"?{ParameterString}");
            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(responseJson);
            }
            return default;
        }

        public void AddParameter(string parameterName, dynamic value)
        {
            if (!_parameterDictionary.ContainsKey(parameterName))
                _parameterDictionary.Add(parameterName, value);
        }

         

        public void ClearParameters() => _parameterDictionary.Clear();
    }
}

