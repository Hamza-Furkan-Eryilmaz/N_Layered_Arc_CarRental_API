using RentACarAPI.Core.DataAccess;
using RentACarAPI.Core.Entities.Concrete;
using RentACarAPI.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarAPI.DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        ICollection<OperationClaim> GetClaims(User user);
    }
}
