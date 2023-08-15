using AutoMapper;
using ERPeople.BLL.ModelsDto;
using ERPeople.DAL.Models;
using ERPeople.DAL.UnitOfWork;

namespace ERPeople.BLL.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LeaveRequestService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreateLeaveRequest(LeaveRequestDto leaveRequestDto)
        {
            var employee =  _unitOfWork.EmployeeRepo.GetById(leaveRequestDto.EmployeeId);

            if (employee == null)
            {
                throw new Exception("Employee not found");
            }

            var createLeaveRequest = new LeaveRequestDto
            {
                EmployeeId = employee.EmployeeId,
                StartDate = leaveRequestDto.StartDate,
                EndDate = leaveRequestDto.EndDate,
                Reason = leaveRequestDto.Reason,
                ApprovalStatus = LeaveApprovalStatus.Pending
            };

            var leaveRequest = _mapper.Map<LeaveRequest>(createLeaveRequest);

             _unitOfWork.LeaveRequestRepo.Add(leaveRequest);
            _unitOfWork.Commit();
        }

        public void ApproveLeaveRequest(int leaveRequestId, int managerId)
        {
            var leaveRequest = _unitOfWork.LeaveRequestRepo.GetById(leaveRequestId);
            if (leaveRequest == null)
            {
                throw new Exception("Leave request not found");
            }

            leaveRequest.ApprovedBy = managerId;
            leaveRequest.ApprovalDate = DateTime.Now;
            leaveRequest.ApprovalStatus = LeaveApprovalStatus.Approved;


            _unitOfWork.LeaveRequestRepo.Update(leaveRequest);
            _unitOfWork.Commit();
          
        }

        public void RejectLeaveRequest(int leaveRequestId, int managerId)
        {
            var leaveRequest = _unitOfWork.LeaveRequestRepo.GetById(leaveRequestId);
            if (leaveRequest == null)
            {
                throw new Exception("Leave request not found");
            }

            leaveRequest.ApprovedBy = managerId;
            leaveRequest.ApprovalDate = DateTime.Now;
            leaveRequest.ApprovalStatus = LeaveApprovalStatus.Rejected;

            _unitOfWork.LeaveRequestRepo.Update(leaveRequest);
            _unitOfWork.Commit();
        }

        public LeaveApprovalStatus GetLeaveRequestStatus(int leaveRequestId)
        {
            var leaveRequest =  _unitOfWork.LeaveRequestRepo.GetById(leaveRequestId);
            if (leaveRequest == null)
            {
                throw new Exception("Leave request not found");
            }

            return leaveRequest.ApprovalStatus;
        }
    }
}
