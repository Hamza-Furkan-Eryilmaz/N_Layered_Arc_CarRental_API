using RentACarAPI.Entity.Concrete;

namespace RentACarAPI.API.Models.CarVM
{
    public class CreateCarVM
    {
        

        public string Model { get; set; }

        public string ModelYear { get; set; }

        public string Description { get; set; }

        public decimal DailyPrice { get; set; }

        public string ColorId { get; set; }

        public string BrandId { get; set; }

        
    }

    public class UpdateCarVM
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public string ModelYear { get; set; }

        public string Description { get; set; }

        public decimal DailyPrice { get; set; }

        public string ColorId { get; set; }

        public string BrandId { get; set; }

        
    }

    public class DeleteCarVM
    {
        public int Id { get; set; }
    }

    public class AddCarImageVM
    {
        public int Id { get; set; }

        public IFormFile ImageUrl { get; set; }
    }
    

    

    
}
