using Business.Abstract;
using Business.Contants;
using Core.Entities.Concrete;
using Core.Utilitis.Results;
using Core.Utilitis.Security.Hashing;
using Core.Utilitis.Security.Jwt;
using Entities.Dtos;

namespace Business.Concrete
{
    internal class AuthManager : IAuthService
    {

        private  IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<Azure.Core.AccessToken> CreateAccessToken(User user)
        {
           var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<Azure.Core.AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto  userForLoginDto )
        {
            var userToChenk = _userService.GetByMail(userForLoginDto.Email);
            if(userToChenk == null )
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToChenk.PasswordHash, userToChenk.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToChenk, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password,out passwordHash, out passwordSalt);
            var User = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(User);
            return new SuccessDataResult<User>(User, Messages.UserRegistered);

        }

        public IResult UserExists(string email)
        {
            if(_userService.GetByMail(email)!= null)
            {
                return new SuccessDataResult<User>(Messages.UserAlredyExits);
            }
            return new SuccessResult();
        }
    }
}
