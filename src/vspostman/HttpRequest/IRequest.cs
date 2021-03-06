﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace VsPostman.HttpRequest
{
    public interface IRequest
    {
        void AddParameter(string parameterName, dynamic value);
        void ClearParameters();
        Task<ResponseObject> Get(string url);
        string ParameterString { get; }
        void AddJsonBody(string jsonString);
        Task<ResponseObject> Post(string url);
    }
}
