using Microsoft.EntityFrameworkCore;
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
        public async Task<string> AddTodo(TodoDto model)
        {
            var TodoEntity = new ToDoModel
            {
                IsDone = model.IsDone,
                Description = model.Description
                
            };

            var todo = await _context.ToDos.AddAsync(TodoEntity);
            await _context.SaveChangesAsync();
            return todo.Entity.Id;
        }

        public async Task<bool> UpdateTodo(string id, TodoDto model)
        {
            var todo = await _context.ToDos.FirstOrDefaultAsync(usr => usr.Id == id);
            if (todo == null)
                return false;

            todo.IsDone = model.IsDone;
            todo.Description = model.Description;
           

            _context.ToDos.Update(todo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<string> DeleteTodo(string id)
        {
            var todo = await _context.ToDos.FirstOrDefaultAsync(x => x.Id == id);

            if (todo == null)
                return "Todo not found!";

            _context.Remove(todo);
            await _context.SaveChangesAsync();
            return "Todo deleted successfully";
        }

       public async Task<string> GetTodo()
        {
            var todo = await _context.ToDos.FirstOrDefaultAsync(x => x.Id == id);
            if (todo == null)
                return null;
            return todo;
        }

        public async Task<ToDoModel> GetById(string id)
        {
            var todo = await _context.ToDos.FirstOrDefaultAsync(x => x.Id == id);
            if (todo == null)
                return null;
            return todo;
        }
        
    }
}

