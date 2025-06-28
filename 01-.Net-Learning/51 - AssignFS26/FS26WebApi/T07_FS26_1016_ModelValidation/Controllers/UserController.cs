using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using T07_FS26_1016_ModelValidation.Models;

namespace T07_FS26_1016_ModelValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Registers a user using automatic model validation based on data annotations.
        /// </summary>
        /// <param name="input">
        /// The user input to be validated via attributes like [Required], [EmailAddress], [Phone], and [MinLength].
        /// </param>
        /// <returns>
        /// Returns 200 OK with a success message if the input is valid, or 400 Bad Request with validation errors if invalid.
        /// </returns>
        [HttpPost("auto")]
        public IActionResult RegisterAuto([FromBody] UserInput input)
        {
            return Ok(new { Message = "User registered via automatic validation." });
        }

        /// <summary>
        /// Registers a user using manual model validation with a unified API response format.
        /// </summary>
        /// <param name="input">
        /// The user input object to validate, received from the request body.
        /// </param>
        /// <returns>
        /// A 200 OK response with a success message if the input is valid;  
        /// otherwise, a 400 Bad Request response containing validation error messages.
        /// </returns>
        [HttpPost("manual")]
        public IActionResult RegisterManual([FromBody] UserInput input)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                                       .SelectMany(v => v.Errors)
                                       .Select(e => e.ErrorMessage)
                                       .ToList();

                return BadRequest(new
                {
                    Message = "Validation failed",
                    Errors = errors
                });
            }

            return Ok(new
            {
                Message = "User registered via manual validation."
            });
        }

    }
}
