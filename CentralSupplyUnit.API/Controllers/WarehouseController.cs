using CentralSupplyUnit.Core.DTOs;
using CentralSupplyUnit.Core.Entities;
using CentralSupplyUnit.Core.Interfaces.Service;
using DocumentFormat.OpenXml.Spreadsheet;
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

        [HttpGet("GetMyWarehouses")]
        [Authorize(Roles = "Manager")]
        public IActionResult GetMyWarehouses()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return Ok(_service.GetAll(userId));
        }
        [HttpGet("GetAllWarehouses")]
        [Authorize(Roles = "Employee")]
        public IActionResult GetAllWarehouses()
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
        public IActionResult AddWithItems( AddWarehouseDto dto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);


            var result = _service.Add(dto, userId);

            if (result == "Warehouse added successfully")
                return Ok(new { message = result });

            return BadRequest(new { message = result });
        }

        [HttpDelete]
        [Authorize(Roles = "Manager")]
        public IActionResult Delete([FromBody] List<int> ids)
        {
            var result = _service.Delete(ids);

            if (result.Contains("not found"))
                return NotFound(result);

            return Ok(result);
        }
        [HttpGet("export")]
        [Authorize(Roles = "Manager")]
        public IActionResult ExportWarehouses()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var fileBytes = _service.ExportWarehousesToExcel(userId);

            return File(
                fileBytes,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Warehouses.xlsx"
            );
        }

    }
}
