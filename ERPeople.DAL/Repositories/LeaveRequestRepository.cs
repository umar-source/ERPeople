﻿using ERPeople.DAL.Data;
using ERPeople.DAL.Interfaces;
using ERPeople.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPeople.DAL.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(ERPeopleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
