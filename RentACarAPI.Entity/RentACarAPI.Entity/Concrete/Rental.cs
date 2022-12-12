using RentACarAPI.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarAPI.Entity.Concrete
{
    public class Rental:BaseEntity
    {
        public int CarId { get; set; }

        public Car car { get; set; }

        public Customer customer { get; set; }

        public DateTime RentDate { get; set; }

        public DateTime ReturnDate { get; set;}
    }
}
