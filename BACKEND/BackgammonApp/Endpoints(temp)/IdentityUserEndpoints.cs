
using BackgammonApp.Configuration;
using BackgammonApp.Models.Auth;
using BackgammonApp.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackgammonApp.Endpoints_temp_
{
    public static class IdentityUserEndpoints
    {
        public static IEndpointRouteBuilder MapIdentityUserEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/signup", CreateUser);

            app.MapPost("/signin", SignIn);

            return app;
        }

        [AllowAnonymous]
        private static async Task<IResult> SignIn(
                    UserManager<AppUser> userManager,
                    [FromBody] LoginModel loginModel,
                    IOptions<AppSettings> appSettings)
        {
            {
                var user = await userManager.FindByEmailAsync(loginModel.Email);

                if (user != null && await userManager.CheckPasswordAsync(user, loginModel.Password))
                {
                    var jwtSecret = appSettings.Value.JWTSecret;
                    var roles = await userManager.GetRolesAsync(user);
                    var signInKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSecret)
                        );
                    ClaimsIdentity claims = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("UserID", user.Id.ToString()),
                            new Claim("Age", (DateTime.Now.Year - user.DateOfBirth.Year).ToString()),
                            new Claim(ClaimTypes.Role, roles.First()),

                        });

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = claims,
                        Expires = DateTime.UtcNow.AddMinutes(30),
                        SigningCredentials = new SigningCredentials(
                            signInKey,
                            SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(securityToken);

                    return Results.Ok(new { token });
                }
                else
                {
                    return Results.BadRequest(new { messsage = "Username or Password is incorrect." });
                }
            }
        }

        [AllowAnonymous]
        private static async Task<IResult> CreateUser(
            UserManager<AppUser> userManager,
            [FromBody] UserRegistrationModel userRegistrationModel)
        {
            {
                AppUser user = new AppUser()
                {
                    UserName = userRegistrationModel.Email,
                    Email = userRegistrationModel.Email,
                    FirstName = userRegistrationModel.FirstName,
                    LastName = userRegistrationModel.LastName,
                    DateOfBirth = DateOnly.FromDateTime(DateTime.Now.AddYears(-userRegistrationModel.Age)),
                };
                var result = await userManager.CreateAsync(
                    user,
                    userRegistrationModel.Password);
                await userManager.AddToRoleAsync(user, userRegistrationModel.Role);

                if (result.Succeeded)
                    return Results.Ok(result);
                else
                    return Results.BadRequest(result);

            }
        }
    }
}
