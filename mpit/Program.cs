using mpit.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using mpit.DataAccess.Repositories;
using mpit.Infastructure.Mapping;
using mpit.Application.Intefaces.Repositories;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;
var env = builder.Environment;

// Add services to the container.

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

//CORS POLICY
services.AddCors(option =>
{
    option.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(env.IsDevelopment()
            ? "https://localhost:3000"
            : "https://ites.vercel.app");
        policy.AllowCredentials();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

services.AddScoped<IUserRepository, UserRepository>();

services.AddAutoMapper(
    typeof(UserAutoMapper));

services.AddDbContext<UserDbContext>(options => 
    options.UseNpgsql(configuration.GetConnectionString(nameof(UserDbContext))));

var app = builder.Build();

using var scope = app.Services.CreateScope();
await using var dbContext = scope.ServiceProvider.GetRequiredService<UserDbContext>();
await dbContext.Database.EnsureCreatedAsync();

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
