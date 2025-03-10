using FinanceTracker.BOL.DTOs;
using System.Threading.Tasks;

namespace FinanceTracker.BLL.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterUserAsync(RegisterUserDto registerDto);
        Task<AuthResponseDto> LoginAsync(LoginUserDto loginDto);
        bool ValidateToken(string token);
    }
}