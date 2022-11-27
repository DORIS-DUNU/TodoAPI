using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoAPI.Data.Model;
using TodoAPI.Repository;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(UserDto model)
        {
            var result = await _userRepository.AddUser(model);
            if (result == null)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUser(string id, UserDto model)
        {
            var user = await _userRepository.UpdateUser(id, model);
            if (user == false)
                return BadRequest();
            return Ok(model);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userRepository.DeleteUser(id);
            if (result == "User not found!")
                return BadRequest(result);
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpGet("get-by-email/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpGet("get-all/{pageNum}/{pageSize}")]
        public async Task<IActionResult> GetAllUsers(int pageNum,  int pageSize)
        {
            var users = await _userRepository.GetAllUsers(new PageQueryHelper
            {
                PageNumber = pageNum,
                PageSize = pageSize
            });
            if (users == null)
                return NotFound();
            return Ok(users);
        }
    }
}
