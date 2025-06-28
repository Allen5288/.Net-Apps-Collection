using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace T04_FS26_1013_ReturnTypes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("json")]
        public JsonResult GetUserAsJson()
        {
            var user = new { Name = "Alice", Age = 30 };

            return new JsonResult(user);
        }

        [HttpGet("check")]
        public IActionResult GetUserById(int id)
        {
            if (id < 0)
            {
                return BadRequest("Invalid ID");
            }

            var user = new { Name = "Bob", Age = 28 };
            return Ok(user);
        }
    }
}
