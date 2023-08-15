using ERPeople.DAL.Interfaces;

namespace ERPeople.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepo { get; }

        IDepartmentRepository DepartmentRepo { get; }

        IAttendanceRepository AttendanceRepo { get; }

        ILeaveRequestRepository LeaveRequestRepo { get; }

        // Add any additional repositories for other entity types here

        void Commit();
        void Rollback();
    }
}
