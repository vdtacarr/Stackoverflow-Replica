using Stackoverflow.Model;

namespace Stackoverflow.Jwt
{
    public interface IAuthService
    {
        public User Login(UserForLoginDto user);
        public User Register(UserForRegisterDto user,string password);

        public string UserExists(UserForRegisterDto user);
        public AccessToken CreateAccessToken(User user);
    }
}
