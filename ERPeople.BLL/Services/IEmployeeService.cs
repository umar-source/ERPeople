
using ERPeople.BLL.ModelsDto;

namespace ERPeople.BLL.Services
{
    public interface IEmployeeService
    {
        void CreateEmployee(EmployeeDto employeeDto);
        void DeleteEmployee(int id);
        IEnumerable<EmployeeDto> GetAllEmployees();
        EmployeeDto GetEmployeeById(int id);
        void UpdateEmployee(EmployeeDto employeeDto);
    }
}