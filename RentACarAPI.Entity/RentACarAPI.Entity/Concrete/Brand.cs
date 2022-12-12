using RentACarAPI.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarAPI.Entity.Concrete
{
    public class Brand:BaseEntity
    {
        public Brand()
        {
            Cars = new HashSet<Car>();
        }
        public string BrandName { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
