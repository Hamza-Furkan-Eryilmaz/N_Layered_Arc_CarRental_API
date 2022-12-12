using Microsoft.AspNetCore.Http;
using RentACarAPI.Core.Utilities.Results;
using RentACarAPI.Entity.Concrete;
using RentACarAPI.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarAPI.Business.Abstract
{
    public interface ICarService
    {
        IDataResult<ICollection<Car>> GetCarsByBrandId(int brandId);

        IDataResult<ICollection<Car>> GetCarsByColorId(int colorId);

        IDataResult<ICollection<CarDetailsDto>> GetCarDetails();       

        IDataResult<Car> GetById(int id);      

        IResult Add(Car car);

        IResult Remove(Car car);
        
        IResult Update(Car car);
    }
}
