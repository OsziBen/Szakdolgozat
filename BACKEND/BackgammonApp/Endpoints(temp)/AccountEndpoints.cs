﻿using BackgammonApp.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BackgammonApp.Endpoints_temp_
{
    public static class AccountEndpoints
    {
        public static IEndpointRouteBuilder MapAccountEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/UserProfile", GetUserProfile);

            return app;
        }

        [Authorize]
        private static async Task<IResult> GetUserProfile(ClaimsPrincipal user,
            UserManager<AppUser> userManager)
        {
            string userID = user.Claims.First(x => x.Type == "userID").Value;
            var userDetails = await userManager.FindByIdAsync(userID);


            return Results.Ok(
                new
                {
                    Email = userDetails?.Email,
                    FirstName = userDetails?.FirstName,
                    LastName = userDetails?.LastName
                });
        }
    }
}
