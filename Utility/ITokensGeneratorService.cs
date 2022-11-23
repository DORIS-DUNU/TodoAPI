using System.Threading.Tasks;
using TodoAPI.Model;

namespace TodoAPI.Utility
{
    public interface ITokensGeneratorService
    {
        Task<string> GenerateTokenAsync(AppUser user);
    }
}
