using Microsoft.AspNetCore.Http;
using RentACarAPI.Core.Entities;
using RentACarAPI.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarAPI.Entity.DTOs
{
    public class CarDetailsDto:IDto
    {
        public int Id { get; set; }     

        public string BrandName { get; set; }

        public string ColorName { get; set; }

        public string ModelYear { get; set; }

        public string Model { get; set; }

        public decimal DailyPrice { get; set; }

        public string Description { get; set; }

        public ICollection<CarImage> Images { get; set; } 
       
    }
}
