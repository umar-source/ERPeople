using AutoMapper;
using ERPeople.BLL.Exceptions;
using ERPeople.BLL.ModelsDto;
using ERPeople.DAL.Models;
using ERPeople.DAL.UnitOfWork;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ERPeople.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            var employees = _unitOfWork.EmployeeRepo.GetAll();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public EmployeeDto GetEmployeeById(int id)
        {
            var employee = _unitOfWork.EmployeeRepo.GetById(id);
            return _mapper.Map<EmployeeDto>(employee);
        }

        public void CreateEmployee(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            _unitOfWork.EmployeeRepo.Add(employee);
            _unitOfWork.Commit();
        }

        public void UpdateEmployee(EmployeeDto employeeDto)
        {

            var existingEmployee = _unitOfWork.EmployeeRepo.GetById(employeeDto.EmployeeId);
            if (existingEmployee == null)
            {
              
                throw new Exception("Employee Not Found");
            }

            // Update entity properties from DTO...
            existingEmployee.FirstName = employeeDto.FirstName;
            existingEmployee.LastName = employeeDto.LastName;
            existingEmployee.Email = employeeDto.Email;
            existingEmployee.DateOfBirth = employeeDto.DateOfBirth;
            existingEmployee.PhoneNumber = employeeDto.PhoneNumber;

            _unitOfWork.EmployeeRepo.Update(existingEmployee);
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
