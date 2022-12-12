using RentACarAPI.Core.Entities.Concrete;
using RentACarAPI.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarAPI.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<ICollection<OperationClaim>> GetClaims(User user);

        IResult Add(User user);

        IDataResult<User> GetByMail(string email);
    }
}
