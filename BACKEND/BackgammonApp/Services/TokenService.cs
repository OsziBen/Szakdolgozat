using BackgammonApp.Configuration;
using BackgammonApp.Interfaces.Services;
using BackgammonApp.Models.User;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackgammonApp.Services
{
    public class TokenService : ITokenService
    {
        private readonly AppSettings _appSettings;

        public TokenService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string CreateToken(AppUser user, IList<string> roles)
        {
            var claims = new[]
            {
                new Claim("userID", user.Id.ToString()),
                new Claim("age", (DateTime.Now.Year - user.DateOfBirth.Year).ToString()),
                new Claim("role", roles.FirstOrDefault() ?? "User"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWTSecret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
