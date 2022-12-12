using RentACarAPI.Business.Abstract;
using RentACarAPI.Business.Constants;
using RentACarAPI.Core.Entities.Concrete;
using RentACarAPI.Core.Utilities.Results;
using RentACarAPI.DataAccess.Abstract;
using RentACarAPI.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarAPI.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            _userDal.SaveChanges();
           
            return new SuccessResult(Messages.UserAdded);
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.Email==email));
        }

        public IDataResult<ICollection<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<ICollection<OperationClaim>>(_userDal.GetClaims(user).ToList()); 
        }
    }
}
