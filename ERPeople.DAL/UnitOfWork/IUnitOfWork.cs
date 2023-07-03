using ERPeople.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPeople.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepo { get; }

        IAttendanceRepository AttendanceRepo { get; }
        IShiftHoursRepository ShiftHoursRepo { get; }

        // Add any additional repositories for other entity types here

        void Commit();
        void Rollback();
    }
}
