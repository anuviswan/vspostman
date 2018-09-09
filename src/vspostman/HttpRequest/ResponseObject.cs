using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VsPostman.HttpRequest
{
    public class ResponseObject
    {
        public WebHeaderCollection Headers { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public TimeSpan ResponseTime { get; set; }
        public string ContendType { get; set; }
        public string ResponseString { get; set; }
        public long Length { get; set; }
    }
}
