using System.Net;

namespace VsPostman.HttpRequest
{
    public interface IHttpWebRequestFactory
    {
        HttpWebRequest Create(string url);
    }
}
