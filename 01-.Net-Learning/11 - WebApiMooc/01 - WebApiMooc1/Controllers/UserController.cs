using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace _01___WebApiMooc1.Controllers
{
    /// <summary>
    /// User Controller - Demonstrates basic CRUD operations
    /// This controller shows how to handle user management with full REST API operations
    /// Route: /api/user
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")] // Specifies default response content type
    public class UserController : ControllerBase
    {
        // In-memory storage for demonstration (in real apps, use database)
        private static List<User> _users = new List<User>
        {
            new User { Id = 1, Name = "John Doe", Email = "john@example.com", Age = 30 },
            new User { Id = 2, Name = "Jane Smith", Email = "jane@example.com", Age = 25 },
            new User { Id = 3, Name = "Bob Johnson", Email = "bob@example.com", Age = 35 }
        };

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// GET: api/user
        /// Retrieves all users with optional pagination
        /// </summary>
        /// <param name="page">Page number (default: 1)</param>
        /// <param name="pageSize">Items per page (default: 10)</param>
        /// <returns>List of users</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<User>> GetUsers([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            _logger.LogInformation("Getting users - Page: {page}, PageSize: {pageSize}", page, pageSize);
            
            var pagedUsers = _users
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Return with pagination metadata in headers
            Response.Headers.Add("X-Total-Count", _users.Count.ToString());
            Response.Headers.Add("X-Page", page.ToString());
            Response.Headers.Add("X-Page-Size", pageSize.ToString());

            return Ok(pagedUsers);
        }

        /// <summary>
        /// GET: api/user/{id}
        /// Retrieves a specific user by ID
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User details</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<User> GetUser(int id)
        {
            _logger.LogInformation("Getting user with ID: {id}", id);
            
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                _logger.LogWarning("User with ID {id} not found", id);
                return NotFound($"User with ID {id} not found");
            }

            return Ok(user);
        }

        /// <summary>
        /// POST: api/user
        /// Creates a new user
        /// </summary>
        /// <param name="user">User data</param>
        /// <returns>Created user</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<User> CreateUser([FromBody] CreateUserRequest user)
        {
            _logger.LogInformation("Creating new user: {name}", user.Name);
            
            // Validate input
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if email already exists
            if (_users.Any(u => u.Email.Equals(user.Email, StringComparison.OrdinalIgnoreCase)))
            {
                return BadRequest("Email already exists");
            }

            var newUser = new User
            {
                Id = _users.Max(u => u.Id) + 1,
                Name = user.Name,
                Email = user.Email,
                Age = user.Age
            };

            _users.Add(newUser);
            
            // Return 201 Created with location header
            return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
        }

        /// <summary>
        /// PUT: api/user/{id}
        /// Updates an entire user record
        /// </summary>
        /// <param name="id">User ID</param>
        /// <param name="user">Updated user data</param>
        /// <returns>Updated user</returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<User> UpdateUser(int id, [FromBody] UpdateUserRequest user)
        {
            _logger.LogInformation("Updating user with ID: {id}", id);
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = _users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return NotFound($"User with ID {id} not found");
            }

            // Update all fields
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Age = user.Age;

            return Ok(existingUser);
        }

        /// <summary>
        /// PATCH: api/user/{id}
        /// Partially updates a user record
        /// </summary>
        /// <param name="id">User ID</param>
        /// <param name="patchUser">Partial user data</param>
        /// <returns>Updated user</returns>
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<User> PatchUser(int id, [FromBody] PatchUserRequest patchUser)
        {
            _logger.LogInformation("Patching user with ID: {id}", id);
            
            var existingUser = _users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return NotFound($"User with ID {id} not found");
            }

            // Update only provided fields
            if (!string.IsNullOrEmpty(patchUser.Name))
                existingUser.Name = patchUser.Name;
            
            if (!string.IsNullOrEmpty(patchUser.Email))
                existingUser.Email = patchUser.Email;
            
            if (patchUser.Age.HasValue)
                existingUser.Age = patchUser.Age.Value;

            return Ok(existingUser);
        }

        /// <summary>
        /// DELETE: api/user/{id}
        /// Deletes a user
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>No content</returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteUser(int id)
        {
            _logger.LogInformation("Deleting user with ID: {id}", id);
            
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound($"User with ID {id} not found");
            }

            _users.Remove(user);
            return NoContent(); // 204 No Content
        }

        /// <summary>
        /// GET: api/user/search
        /// Searches users by name or email
        /// </summary>
        /// <param name="query">Search query</param>
        /// <returns>Matching users</returns>
        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<User>> SearchUsers([FromQuery] string query)
        {
            _logger.LogInformation("Searching users with query: {query}", query);
            
            if (string.IsNullOrWhiteSpace(query))
            {
                return Ok(_users);
            }

            var filteredUsers = _users
                .Where(u => u.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                           u.Email.Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return Ok(filteredUsers);
        }
    }

    /// <summary>
    /// User model for responses
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }
    }

    /// <summary>
    /// Request model for creating users
    /// </summary>
    public class CreateUserRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Range(1, 150)]
        public int Age { get; set; }
    }

    /// <summary>
    /// Request model for updating users
    /// </summary>
    public class UpdateUserRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Range(1, 150)]
        public int Age { get; set; }
    }

    /// <summary>
    /// Request model for partial user updates
    /// </summary>
    public class PatchUserRequest
    {
        [StringLength(100, MinimumLength = 2)]
        public string? Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Range(1, 150)]
        public int? Age { get; set; }
    }
}
