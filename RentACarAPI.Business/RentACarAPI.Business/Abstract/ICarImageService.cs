using Microsoft.AspNetCore.Http;
using RentACarAPI.Core.Utilities.Results;
using RentACarAPI.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarAPI.Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile[] formFiles, CarImage carImage);
    }
}
