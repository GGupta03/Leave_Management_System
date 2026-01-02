using Leave_Management_System.DTO;
using Leave_Management_System.Servies.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Leave_Management_System.Controllers
{

    [ApiController]
    [Route("api/leave")]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveService _service;

        public LeaveController(ILeaveService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult ApplyLeave(ApplyLeaveDto dto)
        {
            _service.ApplyLeave(dto);
            return Ok("Leave applied successfully");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllLeaves());
        }
    }

}
