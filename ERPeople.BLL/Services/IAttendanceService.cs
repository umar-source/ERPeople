using ERPeople.BLL.ModelsDto;
using ERPeople.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPeople.BLL.Services
{
    public interface IAttendanceService
    {
        
        public void CheckIn(int employeeId);
        public void CheckOut(int employeeId);

        public IEnumerable<AttendanceDto> GetEmployeeAttendances(int employeeId);
        public IEnumerable<AttendanceDto> GetLastWeekAttendances(int employeeId);

    }
}
