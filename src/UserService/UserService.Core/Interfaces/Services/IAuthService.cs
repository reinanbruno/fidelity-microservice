using UserService.Core.Models;

namespace UserService.Core.Interfaces.Services
{
    public interface IAuthService
    {
        string GenerateToken(User user);
    }
}
