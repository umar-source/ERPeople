using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPeople.Shared.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; } 
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }

    }
}
