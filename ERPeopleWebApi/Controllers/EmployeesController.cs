using ERPeople.BLL.Exceptions;
using ERPeople.BLL.ModelsDto;
using ERPeople.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace ERPeopleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;


        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService, ILogger<EmployeesController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }


        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDto>> Get()
        {
            try
            {
                var employees = _employeeService.GetAllEmployees();
                return Ok(employees);

            }
            catch (DomainNotFoundException e)
            {
                _logger.LogError($"DomainNotFoundException occurred: {e}");
                throw; // Rethrow the exception to be caught and handled by the ExceptionHandlingMiddleware
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the GetEmployee   action: {ex}  ");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet("{id}")]
        public ActionResult<EmployeeDto> GetById(int id)
        {

            try
            {
                var empId = _employeeService.GetEmployeeById(id);
                if (empId == null)
                {
                    return NotFound();
                }
                return Ok(empId);

            }
            catch (DomainNotFoundException e)
            {
                _logger.LogError($"DomainNotFoundException occurred: {e}");
                throw; // Rethrow the exception to be caught and handled by the ExceptionHandlingMiddleware
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the GetByIdEmployee   action: {ex}  ");
                return StatusCode(500, "Internal server error");
            }

        }


        [HttpPost]
        public ActionResult Create(EmployeeDto employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest("Employee object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                _employeeService.CreateEmployee(employee);
                return Ok();

            }
            catch (DomainBadRequestException e)
            {
                _logger.LogError($"DomainBadRequestException occurred: {e}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the CreateEmployee   action: {ex}  ");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, EmployeeDto employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingEmployee = _employeeService.GetEmployeeById(id);
                if (existingEmployee == null)
                {
                    return NotFound();
                }
                employee.FirstName = existingEmployee.FirstName;
                employee.LastName = existingEmployee.LastName;
                employee.Email = existingEmployee.Email;
                employee.PhoneNumber = existingEmployee.PhoneNumber;
                _employeeService.UpdateEmployee(existingEmployee);
                return Ok();
            }
            catch (DomainNotFoundException e)
            {
                _logger.LogError($"DomainNotFoundException occurred: {e}");
                throw; // Rethrow the exception to be caught and handled by the ExceptionHandlingMiddleware
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the UpdateEmployee action: {ex}  ");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _employeeService.DeleteEmployee(id);
                return Ok();
            }
            catch (DomainNotFoundException e)
            {
                _logger.LogError($"DomainNotFoundException occurred: {e}");
                throw; // Rethrow the exception to be caught and handled by the ExceptionHandlingMiddleware
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the CreateOwner  action: {ex}  ");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
