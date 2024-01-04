using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Exceptions
{
    public class ExceptionModel : ErrorStatusCode
    {
        public IEnumerable<string> Errors { get; set; }
        //ToString edende serialize elesin ovtamatik
        public override string ToString()=> JsonConvert.SerializeObject(this);
        
    }

    public class ErrorStatusCode
    {
        public int StatusCode { get; set; }
    }
}
