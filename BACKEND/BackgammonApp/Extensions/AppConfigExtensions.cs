using BackgammonApp.Configuration;

namespace BackgammonApp.Extensions
{
    public static class AppConfigExtensions
    {
        public static WebApplication ConfigCORS(
    this WebApplication app,
    IConfiguration config)
        {
            app.UseCors();

            return app;
        }

        public static IServiceCollection AddAppConfig(
            this IServiceCollection services,
            IConfiguration config)
        {
            services.Configure<AppSettings>(config.GetSection("AppSettings"));

            return services;
        }
    }
}
