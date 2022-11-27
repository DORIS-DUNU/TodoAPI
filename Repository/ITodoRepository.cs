using System.Collections.Generic;
using System.Threading.Tasks;
using TodoAPI.Data.Model;
using TodoAPI.Model;
using TodoAPI.Model.Dtos;

namespace TodoAPI.Repository
{
    public interface ITodoRepository
    {
        Task<string> AddTodo(string userId, TodoDto model);
        Task<bool> UpdateTodo(string userId, string todoId,  TodoDto model);
        Task<bool> DeleteTodo(string todoId);

        Task<List<ToDoModel>> GetAllTodosForAUser(string userId);

        Task<ToDoModel> GetTodoById(string id);        
    }
}

