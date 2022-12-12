using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarAPI.API.Models.BrandVM;
using RentACarAPI.Business.Abstract;
using RentACarAPI.Entity.Concrete;

namespace RentACarAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;

        public BrandsController(IBrandService brandService, IMapper mapper)
        {
            _brandService = brandService;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public IActionResult Add(BrandViewModel model)
        {
            Brand brand=_mapper.Map<Brand>(model); 
            
            var result= _brandService.Add(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
