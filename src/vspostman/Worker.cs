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
            var client = new ClientService(new HttpWebRequestFactory());
            

            foreach (var item in parameters.Keys)
            {
                client.AddParameter(item, parameters[item]);
            }
            
            return await client.Get(url);
        }
    }
}
