using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPeople.DAL.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }
    
        public DateTime? CheckInTime { get; set; } = null;

        public DateTime? CheckOutTime { get; set; } = null;

        [Required]
        public int EmployeeId { get; set; }
     
        public virtual Employee? Employee { get; set; }
    }
}
