using RentACarAPI.Business.Abstract;
using RentACarAPI.Core.Utilities.Results;
using RentACarAPI.DataAccess.Abstract;
using RentACarAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACarAPI.Entity.Concrete;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace RentACarAPI.Business.Concrete
{
    [Authorize(Roles = "Admin")]
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
           _brandDal.Add(brand);
            _brandDal.SaveChanges();
            return new SuccessResult("brand is added");
        }

        [AllowAnonymous]
        public IDataResult<ICollection<Brand>> GetAll()
        {
           var result= _brandDal.GetList().ToList();
            
            return new SuccessDataResult<ICollection<Brand>>(result);
        }
    }
}
