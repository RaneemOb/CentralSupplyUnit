using CentralSupplyUnit.Core.DTOs;
using CentralSupplyUnit.Core.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CentralSupplyUnit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var token = _service.Login(dto.UserName, dto.Password);

            if (token == null)
                return Unauthorized("Invalid credentials");

            return Ok(new
            {
                token
            });
        }
    }
}
