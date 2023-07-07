using ERPeople.Shared.Models;

namespace ERPeople.BLL.Services
{
    public interface IEmployeeService
    {
        void CreateEmployee(Employee employee);
        void DeleteEmployee(int id);
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        void UpdateEmployee(Employee employee);
    }
}