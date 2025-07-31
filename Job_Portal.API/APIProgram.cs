using Job_Portal.API.Middleware;
using Job_Portal.Data;
using Job_Portal.Repositories.Implementations;
using Job_Portal.Repositories.Interfaces;
using Job_Portal.Services.Implementations;
using Job_Portal.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Text.Json.Serialization;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs/jobportal_logs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=JobPortalDb;Trusted_Connection=True;TrustServerCertificate=True;"));

    builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IJobRepository, JobRepository>();
    builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
    builder.Services.AddScoped<IBookmarkRepository, BookmarkRepository>();

    builder.Services.AddScoped<IJobService, JobService>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IApplicationService, ApplicationService>();
    builder.Services.AddScoped<IBookmarkService, BookmarkService>();
    builder.Services.AddScoped<IDashboardService, DashboardService>();

    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

    app.UseSwagger();
    app.UseSwaggerUI();

    if (app.Environment.IsDevelopment())
    {
        
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    app.MapGet("/", () => " Job Portal API is running!");

    app.Run(); ;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application failed to start");
}
finally
{
    Log.CloseAndFlush();
}