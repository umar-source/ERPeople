using ERPeople.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


//#nullable enable  // or we alternatively declare in project file <Nullable>enable</Nullable>

namespace ERPeopleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [BindProperties(SupportsGet = true)]
    public class TestController : ControllerBase
    {
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("Hello")]
        public IActionResult Hello()
        {
            return Ok("You hit me!");
        }


        [AllowAnonymous]
        [HttpGet("Get")]
        public ActionResult<string> Get(string id, bool? isTest)
        {

            //if (!isTest.HasValue) {
            //     ModelState.AddModelError(nameof(isTest), "isTest is required!");.
            //}
            //if (string.IsNullOrEmpty(id))
            //{
            //    ModelState.AddModelError(nameof(id), "id is required!");.
            //}
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}


            return $"Id: {id} - isTest: {isTest}";
        }

        [AllowAnonymous]
        [HttpPost("Post")]
        public ActionResult<string> Post([FromBody] MyData mydata)
        {
            return $"Name: {mydata.Name} - Age: {mydata.Age} - Email: {mydata.Email} - Phone: {mydata.Phone}";
        }



      //  [BindProperty(SupportsGet = true, Name = "test")]
      //  public bool isTest { get; set; }

        [AllowAnonymous]
        [HttpGet("GetBinding/{id}")]
        public ActionResult<string> GetBinding([FromQuery] MyComplexType myComplexType /*[FromQuery]int id  , [FromHeader(Name = "Accept-Language")] string language */ )
        {
            //  return $"Id: {id} - isTest: {isTest} - Language: {language}";
            return $"Id: {myComplexType.Id} - isTest: {myComplexType.isTest} - Language: {myComplexType.Language} ";
        }




        [AllowAnonymous]
        [HttpPost("PostBinding")]
        public ActionResult<string> PostBinding(MyCustomType myCustomType)
        {
            
            return $"Id: {myCustomType.Id} - Name: {myCustomType.Name}";
        }

    }
}
