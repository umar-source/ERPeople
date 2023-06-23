using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPeople.DAL.Data
{
    public class ERPeopleDbContext : IdentityDbContext
    {
        public ERPeopleDbContext(DbContextOptions<ERPeopleDbContext> options) : base(options) { }
    }
}
