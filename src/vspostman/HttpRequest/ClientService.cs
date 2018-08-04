using LazyCache;
using LazyCache.Providers;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace VsPostman.HttpRequest
{
    public class ClientService : IRequest
    {
        private IAppCache _cache;
        private IDictionary<string, dynamic> _parameterDictionary;

        public string Url { get; set; }

        public string ParameterString => string.Join("&", _parameterDictionary.Select(pair => $"{pair.Key}={pair.Value}"));

        public ClientService(IMemoryCache cache)
        {
            _cache = new CachingService(new MemoryCacheProvider(cache));
            _parameterDictionary = new Dictionary<string, dynamic>();
        }

        public ClientService()
        {
            _parameterDictionary = new Dictionary<string, dynamic>();
        }


        public async Task<string> Get()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
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

