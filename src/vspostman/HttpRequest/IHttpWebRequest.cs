using System.Net;

namespace VsPostman.HttpRequest
{
    public interface IHttpWebRequest
    {
        HttpWebRequest Create(string url);
    }
}
