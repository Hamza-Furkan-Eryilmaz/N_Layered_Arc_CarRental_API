using RentACarAPI.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarAPI.Entity.Concrete
{
    public class CarImage:BaseEntity
    {
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public Car Car { get; set; }
    }
}
