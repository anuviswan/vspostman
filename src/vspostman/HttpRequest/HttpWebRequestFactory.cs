using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VsPostman.HttpRequest
{
    public class HttpWebRequestFactory : IHttpWebRequestFactory
    {
        public HttpWebRequest Create(string url)
        {
            return (HttpWebRequest)WebRequest.Create(url);
        }
    }
}
