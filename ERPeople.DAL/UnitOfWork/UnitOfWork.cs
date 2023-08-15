using ERPeople.DAL.Data;
using ERPeople.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPeople.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ERPeopleDbContext _dbContext;

        public UnitOfWork(ERPeopleDbContext dbContext, 
            IEmployeeRepository EmployeeRepository,
            IDepartmentRepository DepartmentRepository,
            IAttendanceRepository AttendanceRepository,
             ILeaveRequestRepository LeaveRequestRepository
        )
        {
            this._dbContext = dbContext;
            this.EmployeeRepo = EmployeeRepository;
            this.DepartmentRepo = DepartmentRepository;
            this.AttendanceRepo = AttendanceRepository;
            this.LeaveRequestRepo = LeaveRequestRepository;
        }

        // Add private fields for any additional repositories for other entity types here
        public IEmployeeRepository EmployeeRepo { get; private set; }
        public IDepartmentRepository DepartmentRepo { get; private set; }
        public IAttendanceRepository AttendanceRepo { get; private set; }

        public ILeaveRequestRepository LeaveRequestRepo { get; private set; }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Rollback()
        {
            _dbContext.Dispose();
        }
    }
}
