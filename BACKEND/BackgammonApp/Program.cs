using BackgammonApp.Data;
using BackgammonApp.Endpoints_temp_;
using BackgammonApp.Extensions;
using BackgammonApp.Interfaces.Repositories;
using BackgammonApp.Interfaces.Services;
using BackgammonApp.Models.User;
using BackgammonApp.Repositories;
using BackgammonApp.Services;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerExplorer()
                .InjectDbContext(builder.Configuration)
                .AddAppConfig(builder.Configuration)
                .AddIdentityHandlersAndStores()
                .ConfigureIdentityOptions()
                .AddIdentityAuth(builder.Configuration);

// Dependency Injections (method extensions)
//builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

app.ConfigureSwaggerExplorer();

app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();

app.ConfigCORS(builder.Configuration)
   .AddIdentityAuthMiddlewares();

app.MapControllers();

app.MapGroup("/api")
   .MapIdentityApi<AppUser>();

app.MapGroup("/api")
   .MapIdentityUserEndpoints()
   .MapAccountEndpoints()
   .MapAuthorizationEndpoints();

app.Run();
