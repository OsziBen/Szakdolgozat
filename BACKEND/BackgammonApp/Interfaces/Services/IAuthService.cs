using BackgammonApp.DTOs;
using BackgammonApp.DTOs.AppUser;

namespace BackgammonApp.Interfaces.Services
{
    public interface IAuthService
    {
        Task<AuthTokenDTO?> SignInAsync(LoginDTO dto); 
    }
}
