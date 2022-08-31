using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stackoverflow.Jwt
{
    public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }

    }
}
