using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPeople.Shared.Models
{
    public class ShiftHours
    {
        public int ShiftHoursId { get; set; }
        public DateTime Date { get; set; }
        public double Hours { get; set; }
    }
}
