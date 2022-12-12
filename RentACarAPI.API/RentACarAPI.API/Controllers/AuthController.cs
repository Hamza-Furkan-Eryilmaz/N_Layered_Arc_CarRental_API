﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarAPI.Business.Abstract;
using RentACarAPI.Entity.DTOs;

namespace RentACarAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login (UserForLoginDto userForLoginDto) 
        {
            var userToLogin=_authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
                
            }
           var result= _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("Register")]
        public IActionResult Register (UserForRegisterDto userForRegisterDto) 
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success) 
            {
                return BadRequest(userExists.Message);
            }

            var userToRegister = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result=_authService.CreateAccessToken(userToRegister.Data);
            if (result.Success) 
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }
    }
}