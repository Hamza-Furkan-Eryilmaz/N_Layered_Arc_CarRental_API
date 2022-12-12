using RentACarAPI.Core.DataAccess;
using RentACarAPI.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarAPI.DataAccess.Abstract
{
    public interface ICarImageDal:IEntityRepository<CarImage>
    {
    }
}
