using BackgammonApp.Data;
using BackgammonApp.Endpoints_temp_;
using BackgammonApp.Extensions;
using BackgammonApp.Hubs;
using BackgammonApp.Interfaces.Repositories;
using BackgammonApp.Interfaces.Services;
using BackgammonApp.Models.User;
using BackgammonApp.Repositories;
using BackgammonApp.Services;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSignalR();

builder.Services.AddSwaggerExplorer()
                .InjectDbContext(builder.Configuration)
                .AddAppConfig(builder.Configuration)
                .AddIdentityHandlersAndStores()
                .ConfigureIdentityOptions()
                .AddIdentityAuth(builder.Configuration);

// Dependency Injections (method extensions)    !!!
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IAppUserService, AppUserService>();
builder.Services.AddScoped<IUserRegistrationService, UserRegistrationService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();
//builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

app.ConfigureSwaggerExplorer();

app.UseHttpsRedirection();
//app.UseStaticFiles();
app.UseRouting();

app.ConfigureCORS(builder.Configuration)
   .AddIdentityAuthMiddlewares();

app.MapControllers();
app.MapGroup("/api")
    .MapHub<BackgammonHub>("/backgammonHub", options => {
        options.Transports =
            HttpTransportType.WebSockets |
            HttpTransportType.LongPolling;
    });

app.MapGroup("/api")
   .MapIdentityApi<AppUser>();

app.MapGroup("/api")
   /*.MapIdentityUserEndpoints()*/
   /*.MapAccountEndpoints()*/
   /*.MapAuthorizationEndpoints()*/;

app.Run();
