using BackgammonApp.Configuration;

namespace BackgammonApp.Extensions
{
    public static class AppConfigExtensions
    {
        public static WebApplication ConfigureCORS(
            this WebApplication app,
            IConfiguration config)
        {
            app.UseCors(options =>
                options.WithOrigins("https://localhost:4200")
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials());

            return app;
        }

        public static IServiceCollection AddAppConfig(
            this IServiceCollection services,
            IConfiguration config)
        {
            services.Configure<AppSettings>(config.GetSection("AppSettings"));

            var appSettings = config.GetSection("AppSettings").Get<AppSettings>();

            if (string.IsNullOrWhiteSpace(appSettings?.JWTSecret))
                throw new Exception("JWT secret not configured. Please set AppSettings__JWTSecret as an environment variable.");
            
            return services;
        }
    }
}
