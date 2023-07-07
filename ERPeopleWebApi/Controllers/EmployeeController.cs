

using ERPeople.BLL.Services;
using ERPeople.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERPeopleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            var employees = _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }


        [HttpPost("Create")]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.CreateEmployee(employee);
                return Ok();
            }
            return BadRequest(ModelState);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee employee)
        {
            if (ModelState.IsValid)
            {
                var existingEmployee = _employeeService.GetEmployeeById(id);
                if (existingEmployee == null)
                {
                    return NotFound();
                }

                // Update other properties as needed
                _employeeService.UpdateEmployee(existingEmployee);
                return NoContent();
            }
            return BadRequest(ModelState);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _employeeService.DeleteEmployee(id);
            return NoContent();
        }
    }
}
