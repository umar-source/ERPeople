using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPeople.DAL.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }

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

    public enum LeaveType
    {
        Vacation,
        Sick,
        Maternity,
        Paternity,
    }

    public enum LeaveApprovalStatus
    {
        Pending,
        Approved,
        Rejected
    }
}
