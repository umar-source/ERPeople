﻿using ERPeople.BLL.Exceptions;
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
            catch (DomainNotFoundException ex)
            {
                _logger.LogError(ex, "DomainNotFoundException occurred");
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Something went wrong inside the GetAllEmployees action");
                return StatusCode(500, $"Internal server error: {e}");
            }

        }

        [HttpGet("{id}")]
        public ActionResult<EmployeeDto> GetById(int id)
        {

            try
            {
                if (id <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(id));
                }

                
                var emp = _employeeService.GetEmployeeById(id);
                if (emp == null)
                {
                    return NotFound();
                }

                return Ok(emp);

            }
            catch (DomainNotFoundException ex)
            {
                _logger.LogError(ex, "DomainNotFoundException occurred");
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Something went wrong inside the GetByIdEmployee action");
                return StatusCode(500, $"Internal server error: {e}");
            }

        }


        [HttpPost]
        public ActionResult Create([FromBody] EmployeeDto employee)
        {
            try
            {
                
                if (employee == null)
                {

                    throw new ArgumentNullException(nameof(employee));
                }

                _employeeService.CreateEmployee(employee);
                return Ok();

            }
            catch (DomainBadRequestException ex)
            {
                _logger.LogError(ex, "DomainBadRequestException occurred");
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Something went wrong inside the CreateEmployee action");
                return StatusCode(500, $"Internal server error: {e}");
            }
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] EmployeeDto employeeDto)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(id));
                }

                if (employeeDto == null)
                {

                    throw new ArgumentNullException(nameof(employeeDto));
                }

                employeeDto.EmployeeId = id;
                _employeeService.UpdateEmployee(employeeDto);
                return Ok();
            }
            catch (DomainNotFoundException ex)
            {
                _logger.LogError(ex, "DomainNotFoundException occurred");
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Something went wrong inside the GetEmployeeById action");
                return StatusCode(500, $"Internal server error: {e}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {

                if (id <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(id));
                }

                _employeeService.DeleteEmployee(id);
                return NoContent();
            }
            catch (DomainNotFoundException ex)
            {
                _logger.LogError(ex, "DomainNotFoundException occurred");
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Something went wrong inside the DeleteEmployee  action");
                return StatusCode(500, $"Internal server error: {e}");
            }

        }
    }
}
