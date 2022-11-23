using System.Threading.Tasks;
using TodoAPI.Data.Model;
using TodoAPI.Model.Dtos;

namespace TodoAPI.Repository
{
    public interface ITodoRepository
    {
        Task<int> AddTodo(TodoDto model);
        Task<bool> UpdateTodo(string id, TodoDto model);
        Task<int> DeleteTodo(string id);

        Task<int> GetTodo();

        Task<bool> GetById(string id);

        Task<bool> GetByEmail(string email);

        
    }
}

