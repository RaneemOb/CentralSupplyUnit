using CentralSupplyUnit.Core.Entities;
using CentralSupplyUnit.Core.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CentralSupplyUnit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public IActionResult Add([FromBody] Warehouse warehouse)
        {
            var result = _service.Add(warehouse, 1); // userId مؤقت

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
