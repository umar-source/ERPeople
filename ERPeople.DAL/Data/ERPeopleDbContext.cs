
using ERPeople.Shared.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ERPeople.DAL.Data
{
    public class ERPeopleDbContext : IdentityDbContext
    {

        public ERPeopleDbContext(DbContextOptions<ERPeopleDbContext> options) : base(options)
        {

        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> Attendence { get; set; }
        public DbSet<ShiftHours> ShiftHours { get; set; }


    }
}
