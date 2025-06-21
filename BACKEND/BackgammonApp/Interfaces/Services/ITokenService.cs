using BackgammonApp.Models.User;

namespace BackgammonApp.Interfaces.Services
{
    public interface ITokenService
    {
        string CreateToken(AppUser user, IList<string> roles);
    }
}
