using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsPostman.HttpRequest;

namespace VsPostman
{
    public class Worker
    {
        public async Task<ResponseObject> SendGetRequest(string url,IDictionary<string,string> parameters)
        {
            var client = new ClientServiceUsingRestSharp();

            foreach (var item in parameters.Keys)
                client.AddParameter(item, parameters[item]);
            
            return await client.Get(url);
        }

        public async Task<ResponseObject> SendPostRequest(string url, IDictionary<string,string> parameters = null,string jsonBody= null)
        {
            var client = new ClientServiceUsingRestSharp();

            foreach (var item in parameters.Keys)
                client.AddParameter(item, parameters[item]);

            client.AddJsonBody(jsonBody);
            return await client.Post(url);
        }
    }
}
