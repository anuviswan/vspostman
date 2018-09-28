using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsPostman.HttpRequest;

namespace VsPostman.Controls.Response
{
    public interface IHasResponse
    {
        void Update(ResponseObject responseObject);
    }
}
