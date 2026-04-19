using CentralSupplyUnit.Core.DTOs;
using CentralSupplyUnit.Core.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CentralSupplyUnit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplyDocumentController : ControllerBase
    {
        private readonly ISupplyDocumentService _service;

        public SupplyDocumentController(ISupplyDocumentService service)
        {
            _service = service;
        }

        //  Employee - Add
        [Authorize(Roles = "Employee")]
        [HttpPost]
        public IActionResult Add(AddSupplyDocumentDto dto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            _service.Add(dto, userId);
            return Ok(new { message = "Created successfully" });
        }

        //  Employee - My Docs
        [Authorize(Roles = "Employee")]
        [HttpGet("GetMyDocs")]
        public IActionResult GetMyDocs()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            return Ok(_service.GetByUser(userId));
        }

        //  Manager - All Docs
        [Authorize(Roles = "Manager")]
        [HttpGet("GetAllDocs")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        //  Manager - Approve
        [Authorize(Roles = "Manager")]
        [HttpPost("approve/{id}")]
        public IActionResult Approve(int id)
        {
            _service.Approve(id);
            return Ok(new { message = "Approved" });
        }

        //  Manager - Reject
        [Authorize(Roles = "Manager")]
        [HttpPost("reject/{id}")]
        public IActionResult Reject(int id)
        {
            _service.Reject(id);
            return Ok(new { message = "Rejected" });
        }

        //  Employee - Delete own
        [Authorize(Roles = "Employee")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            _service.Delete(id, userId);
            return Ok(new { message = "Deleted" });
        }
    }
}
