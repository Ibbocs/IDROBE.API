using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using IDrobeAPI.Application.Enums;

namespace IDrobeAPI.Application.Interfaces.IResponses
{
    public interface IGenericActionResponse<T>
    {
        bool RequestSuccessful { get; set; }
        string Message { get; set; }
        HttpStatusCode ResponseCode { get; set; }
        public T Data { get; set; }
    }
}
