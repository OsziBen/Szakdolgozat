using BackgammonApp.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace BackgammonApp.Extensions
{
    public static class EFCoreExtensions
    {
        public static IServiceCollection InjectDbContext(
    this IServiceCollection services,
    IConfiguration config)
        {
            var baseConnectionString = config.GetConnectionString("ApplicationDbContext");
            var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

            if (string.IsNullOrEmpty(dbPassword))
                throw new InvalidOperationException("Environment variable 'DB_PASSWORD' is not set.");

            var connectionStringBuilder = new NpgsqlConnectionStringBuilder(baseConnectionString)
            {
                Password = dbPassword
            };

            var fullConnectionString = connectionStringBuilder.ConnectionString;

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(fullConnectionString));

            return services;
        }
    }
}
