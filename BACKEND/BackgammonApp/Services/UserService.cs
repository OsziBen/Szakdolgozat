using BackgammonApp.DTOs.User;
using BackgammonApp.Helpers;
using BackgammonApp.Interfaces.Repositories;
using BackgammonApp.Interfaces.Services;

namespace BackgammonApp.Services
{
    /*
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateAsync(UserCreateDTO userCreateDTO)
        {
            var user = UserDTOConverter.MapToUser(userCreateDTO);

            await _userRepository.CreateAsync(user);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return _userRepository.DeleteAsync(id);
        }

        public async Task<List<UserReadDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return UserDTOConverter.MapToUserReadDTOList(users).ToList();
        }

        public async Task<UserReadDTO?> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            return user != null ? UserDTOConverter.MapToUserReadDTO(user) : null;
        }

        public async Task<UserReadDTO?> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            return user != null ? UserDTOConverter.MapToUserReadDTO(user) : null;
        }

        public async Task<UserUpdateDTO?> UpdateUserAsync(Guid id, UserUpdateDTO userUpdateDTO)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return null;
            }

            UserDTOConverter.MapToExistingUser(user, userUpdateDTO);

            await _userRepository.SaveChangesAsyc();

            return userUpdateDTO;
        }
    }
    */
}
