using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsPostman.HttpRequest;

namespace VsPostman.Controls
{
    interface IResponse
    {
        void Update(ResponseObject response);
    }
}
