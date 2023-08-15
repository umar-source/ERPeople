using ERPeople.BLL.Exceptions;
using ERPeople.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPeopleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;
        private readonly ILogger<AttendanceController> _logger;

        public AttendanceController(IAttendanceService attendanceService, ILogger<AttendanceController> logger)
        {
            _attendanceService = attendanceService;
            _logger = logger;
        }


        [HttpPost("check-in/{employeeId}")]
        public IActionResult CheckIn(int employeeId)
        {

            try
            {
                _attendanceService.CheckIn(employeeId);
                return Ok("Check-in recorded successfully.");
            }
            catch (DomainNotFoundException)
            {
                _logger.LogError($"DomainNotFoundException occurred");
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong inside the CheckOut action");
                return StatusCode(500, $"Internal server error: {e}");
            }
        }

        [HttpPost("check-out/{employeeId}")]
        public IActionResult CheckOut(int employeeId)
        {

            try
            {
                _attendanceService.CheckOut(employeeId);
                return Ok("Check-out recorded successfully.");
            }
            catch (DomainNotFoundException)
            {
                _logger.LogError($"DomainNotFoundException occurred");
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong inside the CheckOut action");
                return StatusCode(500, $"Internal server error: {e}");
            }

        }

        [HttpGet("employee-attendence/{employeeId}")]
        public IActionResult GetEmployeeAttendances(int employeeId)
        {
            try
            {
                var attendances = _attendanceService.GetEmployeeAttendances(employeeId);
                return Ok(attendances);
            }
            catch (DomainNotFoundException)
            {
                _logger.LogError($"DomainNotFoundException occurred");
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong inside the GetEmployeeAttendances action");
                return StatusCode(500, $"Internal server error: {e}");
            }
        }

        [HttpGet("employee-attendence-lastweek/{employeeId}")]
        public IActionResult GetLastWeekAttendances(int employeeId)
        {
            try
            {
                var lastWeekAttendances = _attendanceService.GetLastWeekAttendances(employeeId);
                return Ok(lastWeekAttendances);
            }
            catch (DomainNotFoundException)
            {
                _logger.LogError($"DomainNotFoundException occurred");
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong inside the GetLastWeekAttendances action");
                return StatusCode(500, $"Internal server error: {e}");
            }
        }
    }
}
