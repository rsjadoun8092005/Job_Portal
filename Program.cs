using Job_Portal.Data;
using Job_Portal.models;
using Job_Portal.models.enums;
using Job_Portal.Repositories;
using Job_Portal.Repositories.Implementations;
using Job_Portal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

class Program
{
    static void Main(string[] args)
    {
        User user1 = new User
        (1, "Raghvendra", "rsjadoun8092005@gmail.com", UserRole.JobSeeker);

        Job job1 = new Job
        (
            101,
            "Backend Developer",
            "Work on .Net Backend systems",
            "CodeArrest",
            "Kota",
            DateTime.Now, 0, user1.Id, JobType.Internship
        );

        Application app1 = new Application
        (
            1001,
            job1.Id,
            user1.Id,
            DateTime.Now,
            ApplicationStatus.Pending
        );

        Console.WriteLine($"User: {user1.Name} applied to job: {job1.Title} at {job1.CompanyName} on {app1.ApplicationDate}. Current status: {app1.Status}");

        string connectionString = "Server=.;Database=JobPortalDB;Trusted_Connection=True";

        var services = new ServiceCollection();

        // ✅ DbContext
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

        // ✅ Generic repository
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        // ✅ Custom repositories (MISSING EARLIER)
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IJobRepository, JobRepository>();
        services.AddScoped<IApplicationRepository, ApplicationRepository>();

        // ✅ Build DI container
        var serviceProvider = services.BuildServiceProvider();

        // ✅ Just checking DB connection here
        using (var context = serviceProvider.GetRequiredService<AppDbContext>())
        {
            Console.WriteLine("Connected to the Database!");
        }
    }
}
