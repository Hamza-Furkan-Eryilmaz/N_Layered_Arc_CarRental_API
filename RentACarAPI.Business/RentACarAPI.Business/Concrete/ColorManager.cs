using RentACarAPI.Business.Abstract;
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
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        
        public IResult Add(Color color)
        {
           _colorDal.Add(color);
            _colorDal.SaveChanges();

            return new SuccessResult("Color is added");
        }

        public IDataResult<ICollection<Color>> GetAll()
        {
            var result=_colorDal.GetList().ToList();
            return new SuccessDataResult<ICollection<Color>>(result);
        }
    }
}
