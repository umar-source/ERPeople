using ERPeople.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPeopleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TimeController : ControllerBase
    {

        [HttpPost("check-in")]
        public IActionResult CheckIn()
        {
            return Ok("check-in");
        }


        [HttpPost("check-out")]
        public IActionResult ChechOut()
        {
            return Ok("check-out");
        }


        [HttpGet("attendance-history")]
        public IActionResult AttendanceHistory()
        {
            return Ok("attendance-history");
        }


        [HttpGet("shift-hours")]
        public IActionResult ShiftHours()
        {
            return Ok("shift-hours");
        }


    }
}
