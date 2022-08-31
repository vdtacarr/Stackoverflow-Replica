using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Stackoverflow.Jwt
{
    public static class ClaimExtensions
    {
        public static void AddEmail(this ICollection<Claim> claims, string Email)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email,value:Email));
        }

        public static void AddUserName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, value: name));
        }
        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameId)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, value: nameId));
        }
        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, value: role )));
        }
    }
}
