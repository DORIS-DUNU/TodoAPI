using System.Threading.Tasks;
using TodoAPI.Model.Dtos;

namespace TodoAPI.Service
{
    public interface IAccountService
    {
        Task<string> Register(UserRegistrationModel model);
        Task<LoginResponse> Login(UserLoginModel model);
    }
}
