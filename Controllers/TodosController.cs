using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoAPI.Model.Dtos;
using TodoAPI.Repository;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;
        public TodosController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo(string userId, TodoDto model)
        {
            var result = await _todoRepository.AddTodo(userId, model);
            if (result == null)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateTodo(string userId, string todoId, TodoDto model)
        {
            var result = await _todoRepository.UpdateTodo(userId, todoId, model);
            if (result == false)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTodo(string todoId)
        {
            var result = await _todoRepository.DeleteTodo(todoId);
            if (result == false)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("get-all-for-a-user/{userId}")]
        public async Task<IActionResult> GetAllTodosForAUser(string userId)
        {
            var result = await _todoRepository.GetAllTodosForAUser(userId);
            if (result == null)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoById(string id)
        {
            var result = await _todoRepository.GetTodoById(id);
            if (result == null)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
