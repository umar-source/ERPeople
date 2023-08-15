using ERPeople.BLL.Exceptions;
using ERPeople.BLL.ModelsDto;
using ERPeople.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPeopleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {

        private readonly ILeaveRequestService _leaveRequestService;
        private readonly ILogger<AttendanceController> _logger;

        public LeaveRequestController(ILeaveRequestService leaveRequestService, ILogger<AttendanceController> logger)
        {
            _leaveRequestService = leaveRequestService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult CreateLeaveRequest(LeaveRequestDto leaveRequestDto)
        {
            try
            {
                _leaveRequestService.CreateLeaveRequest(leaveRequestDto);
                return Ok("Leave request created successfully");
            }
            catch (DomainNotFoundException ex)
            {
                _logger.LogError(ex, "DomainNotFoundException occurred");
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Something went wrong inside the CreateLeaveRequest action");
                return StatusCode(500, $"Internal server error: {e}");
            }
        }

        [HttpPost("{leaveRequestId}/approve/{managerId}")]
        public IActionResult ApproveLeaveRequest(int leaveRequestId, int managerId)
        {
            try
            {
                _leaveRequestService.ApproveLeaveRequest(leaveRequestId, managerId);
                return Ok("Leave request approved successfully");
            }
            catch (DomainNotFoundException ex)
            {
                _logger.LogError(ex, "DomainNotFoundException occurred");
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Something went wrong inside the ApproveLeaveRequest action");
                return StatusCode(500, $"Internal server error: {e}");
            }
        }

        [HttpPost("{leaveRequestId}/reject/{managerId}")]
        public IActionResult RejectLeaveRequest(int leaveRequestId, int managerId)
        {
            try
            {
                _leaveRequestService.RejectLeaveRequest(leaveRequestId, managerId);
                return Ok("Leave request rejected successfully");
            }
            catch (DomainNotFoundException ex)
            {
                _logger.LogError(ex, "DomainNotFoundException occurred");
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Something went wrong inside the RejectLeaveRequest action");
                return StatusCode(500, $"Internal server error: {e}");
            }
        }

        [HttpGet("employees/{leaveRequestId}/leaverequest")]
        public IActionResult GetLeaveRequestStatus(int leaveRequestId)
        {
            try
            {
                var status = _leaveRequestService.GetLeaveRequestStatus(leaveRequestId);
                return Ok(status);
            }
            catch (DomainNotFoundException ex)
            {
                _logger.LogError(ex, "DomainNotFoundException occurred");
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Something went wrong inside the GetLeaveRequestStatus action");
                return StatusCode(500, $"Internal server error: {e}");
            }
        }


    }
}
