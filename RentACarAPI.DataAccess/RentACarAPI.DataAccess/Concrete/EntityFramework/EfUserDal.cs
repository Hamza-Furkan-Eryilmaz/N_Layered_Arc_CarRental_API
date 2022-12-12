using Microsoft.EntityFrameworkCore;
using RentACarAPI.Core.DataAccess.EntityFramework;
using RentACarAPI.DataAccess.Abstract;
using RentACarAPI.DataAccess.Concrete.Contexts.RentACarAPIDBContext;
using RentACarAPI.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarAPI.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentACarAPIDbContext>, IUserDal
    {
        public EfUserDal(RentACarAPIDbContext context) : base(context)
        {
        }

        public ICollection<OperationClaim> GetClaims(User user)
        {
            var query = from operationClaim in Context.OperationClaims
                        join userOperationClaim in Context.UserOperationClaims
                        on operationClaim.Id equals userOperationClaim.OperationClaimId
                        where userOperationClaim.UserId == user.Id
                        select new OperationClaim()
                        {
                            Id = operationClaim.Id,
                            Name = operationClaim.Name,
                        };
            return query.AsNoTracking().ToList();
        }
    }
}
