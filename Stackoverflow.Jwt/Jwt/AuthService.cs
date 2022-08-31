using Stackoverflow.Data.Dal.Repository.Abstract;
using Stackoverflow.Model;
using System;
using System.Linq;

namespace Stackoverflow.Jwt
{
    public class AuthService : IAuthService
    {
        private IRepository<User> _repository;

        private ITokenHelper _tokenHelper;
        public AuthService(ITokenHelper tokenHelper, IRepository<User> repository )
        {
            _tokenHelper = tokenHelper;
            _repository = repository;
        }

        public AccessToken CreateAccessToken(User user)
        {
            var accessToken = _tokenHelper.CreateToken(user, );
            return accessToken;
        }

        public User Login(UserForLoginDto user)
        {
            var userToCheck = _repository.GetList().Where(c => c.Password == user.Password).FirstOrDefault();
            if (userToCheck == null)
            {
                return null;
            }
            return userToCheck;
        }
        public string UserExists(UserForRegisterDto user)
        {
            if (_repository.GetList().Where(c => c.Email == user.Email).FirstOrDefault() != null){
                return "Kullanıcı zaten mevcut";
            }
            return "Yeni kullanıcı";    

        }

        public User Register(UserForRegisterDto user, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user1 = new User
            {
                Email = user.Email,
                UserName = "" + user.FirstName + user.LastName,
                FullName = "" + user.FirstName + user.LastName,
                Password = user.Password,
                CreatedAt = DateTime.Now,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            _repository.Add(user1);
            _repository.Save();
            return user1;
        }

    }
}
