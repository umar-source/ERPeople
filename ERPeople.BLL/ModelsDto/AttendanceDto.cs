using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPeople.BLL.ModelsDto
{
    public class AttendanceDto
    {
        public int AttendanceId { get; set; }

        public DateTime? CheckInTime { get; set; } = null;

        public DateTime? CheckOutTime { get; set; } = null;



        [Required]
        public int EmployeeId { get; set; }
    }
}
