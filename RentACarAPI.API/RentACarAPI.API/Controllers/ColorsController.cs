using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarAPI.API.Models.ColorVM;
using RentACarAPI.Business.Abstract;
using RentACarAPI.Entity.Concrete;

namespace RentACarAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _colorService;
        private readonly IMapper _mapper;

        public ColorsController(IColorService colorService, IMapper mapper)
        {
            _colorService = colorService;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public IActionResult Add(ColorViewModel model) 
        {
            
            Color color = _mapper.Map<Color>(model);
            var result = _colorService.Add(color);
            
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
