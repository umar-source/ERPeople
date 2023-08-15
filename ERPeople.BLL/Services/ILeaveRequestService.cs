using ERPeople.BLL.ModelsDto;
using ERPeople.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPeople.BLL.Services
{
    public interface ILeaveRequestService
    {
        public void CreateLeaveRequest(LeaveRequestDto leaveRequestDto);
        public void ApproveLeaveRequest(int leaveRequestId, int managerId);
        public void RejectLeaveRequest(int leaveRequestId, int managerId);

        public LeaveApprovalStatus GetLeaveRequestStatus(int leaveRequestId);
    }
}
