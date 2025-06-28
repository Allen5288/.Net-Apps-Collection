using IMoocService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MoocApi.MoocFilters;
using MoocModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MoocApi.Controllers
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


        [TypeFilter(typeof(MoocActionFilter), Arguments = new object[] { true })]
        [HttpGet()]
        public ApiResult Get(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
                return new ApiResult { Success = false, Data = null, Message = "no users" };

            else
                return new ApiResult { Success = true, Data = user, Message = "success" };
        }

        [HttpPost]
        public ApiResult Add(User user)
        {
            if (!ModelState.IsValid)
            {
                List<string> errorList = new List<string>();
                foreach (var item in ModelState.Keys)
                {
                    if (ModelState[item].Errors != null && ModelState[item].Errors.Count > 0)
                    {
                        foreach (var error in ModelState[item].Errors)
                        {

                            errorList.Add(item + ":" + error.ErrorMessage);
                        }
                    }
                }

                return new ApiResult
                {
                    Success = false,
                    Errors = errorList.ToArray(),
                };

            }

            var isSuccess = _userService.AddUser(user);

            return new ApiResult { Success = isSuccess, Data = user, Message = isSuccess ? "success" : "false" };
        }

        [HttpPut]
        public ApiResult Update(User user)
        {
            if (!ModelState.IsValid)
            {
                List<string> errorList = new List<string>();
                foreach (var item in ModelState.Keys)
                {
                    if (ModelState[item].Errors != null && ModelState[item].Errors.Count > 0)
                    {
                        foreach (var error in ModelState[item].Errors)
                        {

                            errorList.Add(item + ":" + error.ErrorMessage);
                        }
                    }
                }

                return new ApiResult
                {
                    Success = false,
                    Errors = errorList.ToArray(),
                };

            }

            var isSuccess = _userService.UpdateUser(user);

            return new ApiResult { Success = isSuccess, Data = user, Message = isSuccess ? "success" : "false" };
        }

        [HttpDelete("{id}")]
        public ApiResult Delete(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
                return new ApiResult { Success = false, Data = null, Message = "no users" };
            else
            {
                var isSuccess = _userService.DeleteUser(id);
                return new ApiResult { Success = true, Data = user, Message = "success" };
            }

        }

        [HttpGet("Getall")]
        public ApiResult GetAll()
        {
            //throw new NotImplementedException("this is for the global error handling");

            return new ApiResult { Success = true, Data = null, Message = true ? "success" : "false" };
          
        }

        [HttpGet("test")]
        public IActionResult Test(int id)
        {
            return Ok(new { id });
        }
    }
}
