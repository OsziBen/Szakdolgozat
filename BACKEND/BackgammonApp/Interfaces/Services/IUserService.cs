using BackgammonApp.DTOs.User;

namespace BackgammonApp.Interfaces.Services
{
    public interface IUserService
    {
        Task CreateAsync(UserCreateDTO userCreateDTO);

        Task<bool> DeleteAsync(Guid id);

        Task<List<UserReadDTO>> GetAllUsersAsync();

        Task<UserReadDTO?> GetUserByEmailAsync(string email);

        Task<UserReadDTO?> GetUserByIdAsync(Guid id);

        Task<UserUpdateDTO?> UpdateUserAsync(Guid id, UserUpdateDTO userUpdateDTO);
    }
}
