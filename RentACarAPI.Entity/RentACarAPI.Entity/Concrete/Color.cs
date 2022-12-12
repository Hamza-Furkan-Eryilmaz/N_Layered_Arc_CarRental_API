using RentACarAPI.Core.Entities.Concrete;

namespace RentACarAPI.Entity.Concrete
{
    public class Color:BaseEntity
    {
        public Color()
        {
            Cars=new HashSet<Car>();
        }
        public string ColorName { get; set; }

        public ICollection<Car> Cars { get; set; } 
    }
}