
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


        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    //data seeding
        //    //  builder.Entity<Employee>().HasData(
        //    //      new Inventory { Id =1 , Name="Apple", Quantity = 1, Price = 1000},
        //    //      new Inventory { Id = 1, Name = "Banana", Quantity = 9, Price = 1200 },
        //    //      new Inventory { Id = 1, Name = "Cherry", Quantity = 0, Price = 300 },
        //    //      new Inventory { Id = 1, Name = "Gaava", Quantity = 3, Price = 700 },
        //    //      new Inventory { Id = 1, Name = "Pineapple", Quantity = 5, Price = 780 },
        //    //      new Inventory { Id = 1, Name = "Mango", Quantity = 8, Price = 900 }
        //    //);
        //}

    }
}
