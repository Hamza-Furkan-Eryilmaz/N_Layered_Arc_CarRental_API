using Microsoft.EntityFrameworkCore;
using RentACarAPI.Core.DataAccess.EntityFramework;
using RentACarAPI.Core.Utilities.Results;
using RentACarAPI.DataAccess.Abstract;
using RentACarAPI.DataAccess.Concrete.Contexts.RentACarAPIDBContext;
using RentACarAPI.Entity.Concrete;
using RentACarAPI.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACarAPI.DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarAPIDbContext>, ICarDal
    {
        public EfCarDal(RentACarAPIDbContext context) : base(context) { }

        public ICollection<CarDetailsDto> GetCarDetails(Expression<Func<CarDetailsDto, bool>> filter = null)
        {
            var query = (from car in Context.Cars
                         join br in Context.Brands on car.BrandId equals br.Id
                         join co in Context.Colors on car.ColorId equals co.Id



                         select new CarDetailsDto()
                         {
                             Id = car.Id,
                             BrandName = br.BrandName,
                             ColorName = co.ColorName,
                             Model = car.Model,
                             ModelYear = car.ModelYear,
                             DailyPrice = car.DailyPrice,
                             Description = car.Description,
                             Images = Context.CarImages.Count(ci => ci.CarId == car.Id) != 0
                                 ? Context.CarImages.Where(ci => ci.CarId == car.Id).ToList()
                                 : new HashSet<CarImage> { new CarImage {
                                        CarId = car.Id,
                                        ImagePath = "images/default.jpg"
                                    } }


                         });

            return   filter == null
            ? query.AsNoTracking().ToList()
                    : query.AsNoTracking().Where(filter).ToList();

        }
    }
}
