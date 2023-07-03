using ERPeople.DAL.Data;
using ERPeople.DAL.Interfaces;
using ERPeople.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPeople.DAL.Repositories
{
    public class AttendanceRepository : GenericRepository<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(ERPeopleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
