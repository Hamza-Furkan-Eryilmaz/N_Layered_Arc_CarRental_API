using RentACarAPI.Core.DataAccess.EntityFramework;
using RentACarAPI.DataAccess.Abstract;
using RentACarAPI.DataAccess.Concrete.Contexts.RentACarAPIDBContext;
using RentACarAPI.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarAPI.DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarAPIDbContext>, IRentalDal
    {
        public EfRentalDal(RentACarAPIDbContext context) : base(context) { }

    }
}
