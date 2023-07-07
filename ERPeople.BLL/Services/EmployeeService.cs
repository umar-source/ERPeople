

using ERPeople.DAL.UnitOfWork;
using ERPeople.Shared.Models;

namespace ERPeople.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IEnumerable<Employee> GetAllEmployees()
        {
            return _unitOfWork.EmployeeRepo.GetAll();
        }

        public Employee GetEmployeeById(int id)
        {
            return _unitOfWork.EmployeeRepo.GetById(id);
        }

        public void CreateEmployee(Employee employee)
        {
            _unitOfWork.EmployeeRepo.Add(employee);
            _unitOfWork.Commit();
        }

        public void UpdateEmployee(Employee employee)
        {
            _unitOfWork.EmployeeRepo.Update(employee);
            _unitOfWork.Commit();
        }

        public void DeleteEmployee(int id)
        {
            var employee = _unitOfWork.EmployeeRepo.GetById(id);
            if (employee != null)
            {
                _unitOfWork.EmployeeRepo.Delete(employee);
                _unitOfWork.Commit();
            }
        }

 
    }
}
