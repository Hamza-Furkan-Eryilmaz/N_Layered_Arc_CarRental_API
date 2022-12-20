using RentACarAPI.Business.Abstract;
using RentACarAPI.Business.Constants;
using RentACarAPI.Core.Entities.Concrete;
using RentACarAPI.Core.Utilities.Results;
using RentACarAPI.Core.Utilities.Security.Hashing;
using RentACarAPI.Core.Utilities.Security.Jwt;
using RentACarAPI.DataAccess.Abstract;
using RentACarAPI.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarAPI.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        

        public AuthManager(ITokenHelper tokenHelper, IUserService userService)
        {

            _tokenHelper = tokenHelper;
            _userService = userService;
           
        }

        private readonly ITokenHelper _tokenHelper;

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
           var accessToken= _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken,Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login (UserForLoginDto userForLoginDto)
        {
            var userToCheck= _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null) 
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash (userForLoginDto.Password,userToCheck.Data.PasswordHash,userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck.Data,Messages.LoginSuccess);

        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password,out passwordHash,out passwordSalt);

            var userToAdd = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true

            };
            _userService.Add(userToAdd);
            
            
            
            return new SuccessDataResult<User>(userToAdd, Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            var result = _userService.GetByMail(email);

            if (result.Data!=null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
