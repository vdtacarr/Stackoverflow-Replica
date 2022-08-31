using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Stackoverflow.Model;
using Stackoverflow.jwt;
using Newtonsoft.Json;

namespace Stackoverflow.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = new TokenOptions{
            Audience= "www.vedat.com",
            Issuer= "www.vedat.com",
            AccessTokenExpiration= 10,
            SecurityKey= "mypreciouskeypreciouskey"
            };
        }
        public AccessToken CreateToken(User user)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
            var signingCredentials = SigningCredentialsHelper.CreateSigingCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,  SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience:tokenOptions.Audience,
                expires:_accessTokenExpiration,  
                notBefore:DateTime.Now,
                signingCredentials:signingCredentials
                
                );
            return jwt;
        }
       
        private IEnumerable<Claim> SetClaims(User user)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.ID.ToString());
            claims.AddEmail(user.Email);
            claims.AddUserName(user.UserName);
            return claims;
        }

    }
}
