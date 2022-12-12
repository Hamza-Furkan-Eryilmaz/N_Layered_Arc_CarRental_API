using RentACarAPI.Core.Entities.Concrete;
using RentACarAPI.Core.Utilities.Results;
using RentACarAPI.Core.Utilities.Security.Jwt;
using RentACarAPI.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarAPI.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto,string password );

        IDataResult<User> Login(UserForLoginDto userForLoginDto);

        IResult UserExists(string email);

        IDataResult<AccessToken> CreateAccessToken(User user);



    }
}
