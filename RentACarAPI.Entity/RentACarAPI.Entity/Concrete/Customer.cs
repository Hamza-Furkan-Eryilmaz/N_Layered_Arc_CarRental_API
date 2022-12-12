using RentACarAPI.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarAPI.Entity.Concrete
{
    public class Customer:BaseEntity
    {
        public Customer()
        {
            Rentals = new HashSet<Rental>();
        }
        public string CustomerName { get; set; }

        public ICollection<Rental> Rentals { get; set; }
    }
}
