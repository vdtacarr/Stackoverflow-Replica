using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stackoverflow.jwt
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigingCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        } 
    }
}
