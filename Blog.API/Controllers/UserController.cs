using Blog.Core.Entities;
using Blog.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return users == null ? NotFound() : Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            bool success = _userService.AddUser(user);
            return success ? Ok() : NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            bool success = _userService.UpdateUser(id, user);
            return success ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            bool success = _userService.DeleteUser(id);
            return success ? Ok() : NotFound();
        }
    }
}
