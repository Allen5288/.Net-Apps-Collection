using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using T06_FS26_1015_BindingParameters.Models;

namespace T06_FS26_1015_BindingParameters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("[action]/{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok($"You requested user with ID: {id}");
        }

        [HttpGet("[action]")]
        public IActionResult GetUserByName([FromQuery] string name, [FromQuery] int age)
        {
            return Ok($"You requested user: Name = {name}, Age = {age}");
        }

        [HttpPost("create")]
        public IActionResult CreateUser([FromBody] User user)
        {
            return Ok($"Create user: Name = {user.Name}, Age = {user.Age}");
        }
    }
}
