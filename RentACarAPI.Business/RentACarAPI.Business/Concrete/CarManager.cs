using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata;
using RentACarAPI.Business.Abstract;
using RentACarAPI.Business.Constants;
using RentACarAPI.Business.ValidationRules;
using RentACarAPI.Core.CrossCuttingConcerns.Validation;
using RentACarAPI.Core.Utilities.Results;
using RentACarAPI.DataAccess.Abstract;
using RentACarAPI.Entity.Concrete;
using RentACarAPI.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarAPI.Business.Concrete
{
   
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
       
        

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
           
            
        }

        public IResult Add(Car car)
        {
            ValidationTool.Validate(new CarValidator(), car);

            _carDal.Add(car);
            _carDal.SaveChanges();
            
            return new SuccessResult(Messages.CarAddedMessage);
        }

        
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        [AllowAnonymous]
        public IDataResult<ICollection<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<ICollection<CarDetailsDto>>(_carDal.GetCarDetails(),"Car details listed!");                                  
        }

        [AllowAnonymous]
        public IDataResult<ICollection<Car>> GetCarsByBrandId(int brandId)
        {           
            return new SuccessDataResult<ICollection<Car>>(_carDal.GetList(c => c.BrandId == brandId).ToList());
        }

        [AllowAnonymous]
        public IDataResult<ICollection<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<ICollection<Car>>(_carDal.GetList(c => c.ColorId == colorId).ToList());
        }

        public IResult Remove(Car car)
        {
            Car carToDelete = _carDal.Get(c => c.Id == car.Id);
            _carDal.Delete(carToDelete);
            _carDal.SaveChangesAsync();
            return new SuccessResult("Car is deleted");
        }

        public IResult Update(Car car)
        {
           _carDal.Update(car);
            _carDal.SaveChangesAsync();
            return new SuccessResult("Car is updated!");
        }
    }
}
