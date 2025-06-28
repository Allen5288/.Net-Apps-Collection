using FS26WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FS26WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("info")]
        public IActionResult GetUserInfo()
        {
            var result = _userService.GetUserInfo();
            return Ok(result);
        }

        [HttpGet("fail")]
        public IActionResult Fail()
        {
            throw new Exception("Something went wrong!");
        }

    }
}
