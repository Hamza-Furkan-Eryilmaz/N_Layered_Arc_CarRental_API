using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarAPI.Business.Abstract;
using RentACarAPI.Business.Concrete;
using RentACarAPI.Entity.Concrete;

namespace RentACarAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private readonly ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("addMultipleImage")]
        public IActionResult AddMultipleImage([FromForm] IFormFile[] images, [FromForm] int carId)
        {
            var result = _carImageService.Add(images, new CarImage { CarId = carId });
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
