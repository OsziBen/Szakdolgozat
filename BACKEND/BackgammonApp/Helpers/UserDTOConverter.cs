using BackgammonApp.Data;
using BackgammonApp.DTOs.User;

namespace BackgammonApp.Helpers
{
    public static class UserDTOConverter
    {
        /*
        public static List<UserReadDTO> MapToUserReadDTOList(IEnumerable<User> users)
        {
            return users.Select(MapToUserReadDTO).ToList();
        }

        public static User MapToUser(UserCreateDTO dto) => new()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            PasswordHash = dto.Password,
            Age = dto.Age,
            CreatedAt = DateTime.UtcNow,
            Role = "User"
        };

        public static UserReadDTO MapToUserReadDTO(User user) => new()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email ?? string.Empty,
            Age = user.Age,
            Role = user.Role,
            CreatedAt = user.CreatedAt
        };

        public static void MapToExistingUser(User user, UserUpdateDTO dto)
        {
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Age = dto.Age;
        }
        */
    }
}
