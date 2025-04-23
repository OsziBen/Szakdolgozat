using BackgammonApp.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var baseConnectionString = builder.Configuration.GetConnectionString("ApplicationDbContext");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

var connectionStringBuilder = new NpgsqlConnectionStringBuilder(baseConnectionString)
{
    Password = dbPassword
};

var fullConnectionString = connectionStringBuilder.ConnectionString;


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(fullConnectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
