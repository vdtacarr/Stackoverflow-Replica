using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Stackoverflow.Model;

namespace Stackoverflow.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user);
        
    }
}
