using System.Collections.Generic;
using System.Threading.Tasks;
using TodoAPI.Data.Model;
using TodoAPI.Model;

namespace TodoAPI.Repository
{
    public interface IUserRepository 
    {
        Task<string> AddUser(UserDto model);
        Task<bool> UpdateUser(string id, UserDto model);
        Task<string> DeleteUser(string id);
        Task<AppUser> GetUserById(string id);
        Task<AppUser> GetUserByEmail(string email);
        Task<List<AppUser>> GetAllUsers(PageQueryHelper pageHelper);
    }
}
