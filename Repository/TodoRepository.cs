using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.Data;
using TodoAPI.Model;
using TodoAPI.Model.Dtos;

namespace TodoAPI.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDbContext _context;
        public TodoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddTodo(string userId, TodoDto model)
        {
            var user = await _context.Users.Include(x=>x.Todos)
                .FirstOrDefaultAsync(x=>x.Id == userId);
            if (user == null)
                return null;
            var todo = new ToDoModel
            {
                UserId = userId,
                Task = model.Task,
                Description = model.Description,
                IsDone = model.IsDone,
            };
            var addedTodo = await _context.ToDos.AddAsync(todo);
            await _context.SaveChangesAsync();
            return addedTodo.Entity.Id;
        }

        public async Task<bool> DeleteTodo(string todoId)
        {
            var todo = await _context.ToDos.FirstOrDefaultAsync(x=>x.Id==todoId);
            if (todo == null)
                return false;
            _context.ToDos.Remove(todo);
            return true;
        }

        public async Task<List<ToDoModel>> GetAllTodosForAUser(string userId)
        {
            var todos = await _context.ToDos.Where(x=>x.UserId == userId).ToListAsync();
            if (!todos.Any())
                return null;
            return todos;
        }

        public async Task<ToDoModel> GetTodoById(string todoId)
        {
            var todo = await _context.ToDos.FirstOrDefaultAsync(x => x.Id == todoId);
            if (todo == null)
                return null;
            return todo;
        }

        public async Task<bool> UpdateTodo(string userId, string todoId, TodoDto model)
        {
            var todo = await _context.ToDos.FirstOrDefaultAsync(x => x.UserId == userId && x.Id == todoId);
            if (todo == null)
                return false;
            todo.IsDone = model.IsDone;
            todo.Description = model.Description;
            todo.Task = model.Task;
            _context.ToDos.Update(todo);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

