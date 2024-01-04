using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Infrastructure.Models
{
    //tip guvenli olsun deye ve ya appsettingsi deyisdirmek ola biler kod ile bu sayede
    public class TokenSettings
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string Secret { get; set; }
        public int TokenValidityInMunitues { get; set; }
    }
}
