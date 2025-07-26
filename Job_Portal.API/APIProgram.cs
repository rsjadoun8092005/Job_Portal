using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Job_Portal.Data;
using Job_Portal.Repositories.Interfaces;
using Job_Portal.Repositories.Implementations;
using Job_Portal.Services.Interfaces;
using Job_Portal.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// 1. Connect to your SQL Server database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=JobPortalDb;Trusted_Connection=True;TrustServerCertificate=True;"));

// 2. Register your generic repository pattern for any entity like Job/User/Application
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IBookmarkRepository, BookmarkRepository>();

builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<IBookmarkService, BookmarkService>();

// 4. Required for controllers and Swagger UI
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 5. Swagger setup to test APIs easily
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 6. Enable HTTPS and controller routing
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// 7. Optional: Root testing endpoint
app.MapGet("/", () => " Job Portal API is running!");

app.Run();