using ERPeople.DAL.Models;
using System.ComponentModel.DataAnnotations;
namespace ERPeople.BLL.ModelsDto
{
    public class LeaveRequestDto
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [MaxLength(500)]
        public string? Reason { get; set; }

        public int? ApprovedBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ApprovalDate { get; set; }

        [EnumDataType(typeof(LeaveType))]
        public LeaveType LeaveType { get; set; }

        [EnumDataType(typeof(LeaveApprovalStatus))]
        public LeaveApprovalStatus ApprovalStatus { get; set; }
    }
}
