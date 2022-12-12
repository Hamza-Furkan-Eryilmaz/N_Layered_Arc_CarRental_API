using RentACarAPI.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarAPI.Entity.Concrete
{
    public class Car:BaseEntity
    {
        public Car()
        {
            Images = new HashSet<CarImage>();
        }
        public int BrandId { get; set; }

        public int ColorId { get; set; }       

        public string Model { get; set; }

        public string ModelYear { get; set; }

        public string Description { get; set; } 

        public decimal DailyPrice { get; set; }

        public ICollection<CarImage> Images { get; set; }

        public Brand Brand { get; set; }

        public Color Color { get; set; }

        public Rental Rental { get; set; }


    }
}
