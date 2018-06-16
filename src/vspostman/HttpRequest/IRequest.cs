using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsPostman.HttpRequest
{
    public interface IRequest
    {
        string Url { get; set; }
        void AddParameter(string parameterName, dynamic value);
        void Get();
    }
}
