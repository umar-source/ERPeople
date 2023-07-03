
using ERPeople.DAL.UnitOfWork;
using ERPeople.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPeopleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _studentService;

        public EmployeeController(IUnitOfWork studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            var students = _studentService.EmployeeRepo.GetAll();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            var student = _studentService.EmployeeRepo.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public ActionResult Create(Employee student)
        {
            if (ModelState.IsValid)
            {
                _studentService.EmployeeRepo.Add(student);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee student)
        {
            if (ModelState.IsValid)
            {
                var existingStudent = _studentService.EmployeeRepo.GetById(id);
                if (existingStudent == null)
                {
                    return NotFound();
                }

              
                // Update other properties as needed

                _studentService.EmployeeRepo.Update(existingStudent);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _studentService.EmployeeRepo.GetById(id);
            if (student == null)
            {
                return NotFound();
            }

            _studentService.EmployeeRepo.Delete(student);
            return NoContent();
        }
    }
}
