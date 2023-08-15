

using ERPeople.DAL.Data;
using ERPeople.DAL.Interfaces;
using ERPeople.DAL.Models;

namespace ERPeople.DAL.Repositories
{
    public class AttendanceRepository : GenericRepository<Attendance>, IAttendanceRepository
    {
        private readonly ERPeopleDbContext _dbContext;
        public AttendanceRepository(ERPeopleDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Attendance> GetAttendancesByEmployeeId(int employeeId)
        {
            return _dbContext.Attendences.Where(a => a.EmployeeId == employeeId).ToList();
        }

        public IEnumerable<Attendance> GetAttendancesByEmployeeIdAndDateRange(int employeeId, DateTime startDate, DateTime endDate)
        {
            return _dbContext.Attendences.Where(a => a.EmployeeId == employeeId && a.CheckInTime >= startDate && a.CheckInTime <= endDate).ToList();
        }
    }
}
