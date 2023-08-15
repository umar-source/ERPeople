using ERPeople.DAL.Models;
using ERPeople.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPeople.DAL.Interfaces
{
    public interface IAttendanceRepository : IGenericRepository<Attendance>
    {
        public IEnumerable<Attendance> GetAttendancesByEmployeeId(int employeeId);

        public IEnumerable<Attendance> GetAttendancesByEmployeeIdAndDateRange(int employeeId, DateTime startDate, DateTime endDate);

    }
}

