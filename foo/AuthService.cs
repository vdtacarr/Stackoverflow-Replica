using Stackoverflow.Jwt;
using Stackoverflow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace stackoverflow
{
    public class AuthService : IAuth
    {
        HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            httpClient = _httpClient;
        }

        public async Task Login(UserForLoginDto loginModel)
        {
            throw new NotImplementedException();
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }
    }
}
