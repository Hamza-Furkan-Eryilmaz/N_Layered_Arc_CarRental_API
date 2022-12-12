using FluentValidation;
using RentACarAPI.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarAPI.Business.ValidationRules
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c=>c.ColorId).NotEmpty();
            RuleFor(c=>c.BrandId).NotEmpty();
            RuleFor(c => c.DailyPrice).NotEmpty();  
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c=>c.Model).NotEmpty();
          

            RuleFor(c => c.DailyPrice).GreaterThan(0);
        }
    }
}
