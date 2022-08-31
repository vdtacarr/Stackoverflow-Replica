using Stackoverflow.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stackoverflow
{
    public interface IAuth
    {
        Task Login(UserForLoginDto loginModel);
        Task Logout();
    }
}
