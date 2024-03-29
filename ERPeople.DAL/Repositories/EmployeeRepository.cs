﻿using ERPeople.DAL.Data;
using ERPeople.DAL.Interfaces;
using ERPeople.DAL.Models;

namespace ERPeople.DAL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ERPeopleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
