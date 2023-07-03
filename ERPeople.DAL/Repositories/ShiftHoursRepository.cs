using ERPeople.DAL.Data;
using ERPeople.DAL.Interfaces;
using ERPeople.Shared.Models;


namespace ERPeople.DAL.Repositories
{
    public class ShiftHoursRepository : GenericRepository<ShiftHours>, IShiftHoursRepository
    {
        public ShiftHoursRepository(ERPeopleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
