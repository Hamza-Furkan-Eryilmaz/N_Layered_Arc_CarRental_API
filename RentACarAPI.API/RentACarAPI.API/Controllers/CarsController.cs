using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarAPI.API.Models;
using RentACarAPI.API.Models.CarVM;
using RentACarAPI.Business.Abstract;
using RentACarAPI.Entity.Concrete;
using RentACarAPI.Entity.DTOs;

namespace RentACarAPI.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

      


        public CarsController(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
           
        }
        [HttpPost("AddCarImage")]
        public IActionResult AddCarImage(AddCarImageVM model) 
        {
           
           

            return Ok();

        }
        [HttpPost("add")]
        public IActionResult Add(CreateCarVM model) 
        {

            Car car=_mapper.Map<Car>(model);
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("update")]
        public IActionResult Update(UpdateCarVM model) 
        {
            Car car = _mapper.Map<Car>(model);
            var result=_carService.Update(car);
            if (result.Success) 
            {
                return Ok(result);
            }
            return BadRequest();
        }

        

        
        [HttpDelete("delete")]
        public IActionResult Delete(DeleteCarVM model) 
        {
            Car car = _mapper.Map<Car>(model);
            var result = _carService.Remove(car);
            if (result.Success) 
            {
                return Ok(result);
            }
            return BadRequest();
        }

        
        [HttpGet("cardetails")]
        public IActionResult GetCarDetails()
        {           
            var result = _carService.GetCarDetails();
            if (result.Success) 
            {
                return Ok(result);
            }
            return BadRequest();
        }

        
    }
}
