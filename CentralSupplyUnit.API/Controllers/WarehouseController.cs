using CentralSupplyUnit.Core.Entities;
using CentralSupplyUnit.Core.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CentralSupplyUnit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _service;

        public WarehouseController(IWarehouseService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            if (result == null)
                return NotFound("Warehouse not found");

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult Add([FromBody] Warehouse warehouse)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = _service.Add(warehouse, userId); 

            if (result.Contains("required") || result.Contains("unique"))
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);

            if (result.Contains("not found"))
                return NotFound(result);

            return Ok(result);
        }

    }
}
