using Microsoft.AspNetCore.Http;
using RentACarAPI.Business.Abstract;
using RentACarAPI.Business.Constants;
using RentACarAPI.Core.Utilities.Helpers.FileHelper;
using RentACarAPI.Core.Utilities.Results;
using RentACarAPI.DataAccess.Abstract;
using RentACarAPI.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarAPI.Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile[] formFiles, CarImage carImage)
        {
            foreach (var file in formFiles)
            {
                string imageName = string.Format(@"{0}.jpg", Guid.NewGuid());
                carImage.ImagePath = Paths.CarImagePath + imageName;

                carImage.Id = 0;

                FileHelper.Write(file, Paths.RootPath + carImage.ImagePath);

                

                _carImageDal.Add(carImage);
               
            }
            _carImageDal.SaveChanges();
            return new SuccessResult(Messages.ImageAdded);
        }
    }
    
}
