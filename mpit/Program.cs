using mpit.DataAccess.DbContexts;
using mpit.DataAccess.Repositories;
using mpit.Infastructure.Mapping;
using mpit.Application.Intefaces.Repositories;
using mpit.Application.Intefaces.Services;
using mpit.Application.Services;
using mpit.Application.Intefaces.Auth;
using mpit.Infastructure.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.CookiePolicy;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;
var env = builder.Environment;

//CORS POLICY
services.AddCors(option =>
{
    option.AddDefaultPolicy(policy =>
    {
        string[] origins = env.IsDevelopment() 
            ? ["https://localhost:3000", "http://localhost:3000"]
            : ["https://ites.vercel.app"];
        Console.WriteLine(string.Join(", ", origins));
        policy.WithOrigins(origins);
        policy.AllowCredentials();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

// Add services to the container.

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();


services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IVacancyRepository, VacancyRepository>();

services.AddScoped<IUserService, UserService>();
services.AddScoped<VacancyService>();

services.AddScoped<IPasswordHasher, PasswordHasher>();

services.AddAutoMapper(
    typeof(UserAutoMapper));

services.AddDbContext<ApplicationDbContext>(options => 
    options.UseNpgsql(configuration.GetConnectionString(nameof(ApplicationDbContext))));

var app = builder.Build();

using var scope = app.Services.CreateScope();
await using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
await dbContext.Database.EnsureCreatedAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always,
});

app.MapControllers();

app.UseCors();

app.UseAuthorization();

app.Run();
