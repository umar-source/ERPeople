using ERPeople.BLL.Exceptions;
using ERPeople.BLL.ModelsDto;
using ERPeople.BLL.Services;
using Microsoft.AspNetCore.Mvc;


namespace ERPeopleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly ILogger<DepartmentController> _logger;

        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService, ILogger<DepartmentController> logger)
        {
            _departmentService = departmentService;
            _logger = logger;
        }


        [HttpGet]
        public ActionResult<IEnumerable<DepartmentDto>> Get()
        {
            try
            {
                var departments =  _departmentService.GetAllDepartment();
                return  Ok(departments);

            }
            catch (DomainNotFoundException ex)
            {
                _logger.LogError(ex, "DomainNotFoundException occurred");
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Something went wrong inside the GetAllDepartment action");
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

                var dep = _departmentService.GetDepartmentById(id);

                if (dep == null)
                {
                    NotFound();
                }

                return Ok(dep);

            }
            catch (DomainNotFoundException ex)
            {
                _logger.LogError(ex, "DomainNotFoundException occurred");
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Something went wrong inside the GetDepartmentById action");
                return StatusCode(500, $"Internal server error: {e}");
            }

        }


        [HttpPost]
        public ActionResult Create([FromBody] DepartmentDto departmentDto)
        {
            try
            {
                if (departmentDto == null)
                {

                    throw new ArgumentNullException(nameof(departmentDto));
                }


                _departmentService.CreateDepartment(departmentDto);
                return Ok();

            }
            catch (DomainBadRequestException ex)
            {
                _logger.LogError(ex, "DomainBadRequestException occurred.");
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Something went wrong inside the CreateDepartment   action");
                return StatusCode(500, $"Internal server error {e}");
            }
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] DepartmentDto departmentDto)
        {
            try
            {
                if (id <= 0) {
                    throw new ArgumentOutOfRangeException(nameof(id));
                }

                if (departmentDto == null) {

                    throw new ArgumentNullException(nameof(departmentDto));
                }

                departmentDto.DepartmentId = id;
                _departmentService.UpdateDepartment(departmentDto);
                return Ok();
            }
            catch (DomainNotFoundException ex)
            {
                _logger.LogError(ex, "DomainNotFoundException occurred");
                // return NotFound(ex.Message);
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Something went wrong inside the UpdateDepartment action");
                return StatusCode(500, $"Internal server error {e}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _departmentService.DeleteDepartment(id);
                return NoContent();
            }
            catch (DomainNotFoundException ex)
            {
                _logger.LogError(ex, "DomainNotFoundException occurred");
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Something went wrong inside the DeleteDepartment  action");
                return StatusCode(500, $"Internal server error: {e}");
            }
        }
    }
}
