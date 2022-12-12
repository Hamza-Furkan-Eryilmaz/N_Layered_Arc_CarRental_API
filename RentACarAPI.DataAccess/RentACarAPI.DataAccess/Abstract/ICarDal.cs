using RentACarAPI.Core.DataAccess;
using RentACarAPI.Entity.Concrete;
using RentACarAPI.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACarAPI.DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        ICollection<CarDetailsDto> GetCarDetails(Expression<Func<CarDetailsDto, bool>> filter = null);
    }
}
