using CentralSupplyUnit.Core.DTOs;
using CentralSupplyUnit.Core.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CentralSupplyUnit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _service;

        public ItemController(IItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult Add(AddItemDto dto)
        {
            _service.Add(dto);
            return Ok("Item added successfully");
        }
    }
}
