using System;
using Job_Portal.models;
using Job_Portal.models.enums;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Job_Portal.Data;

class Program
{
    static void Main(string[] args)
    {
        User user1 = new User
        (1,"Raghvendra","rsjadoun8092005@gmail.com",UserRole.JobSeeker);

        Job job1 = new Job
        (
            101,
            "Backend Developer",
            "Work on .Net Backend systems",
            "CodeArrest",
            "Kota",
            DateTime.Now,0,user1.Id,JobType.Internship
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

        string connectionString = "Server =.;Database=JobPortaDB;Trusted_Connection=True";

        var services = new ServiceCollection();

        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

        var serviceProvider = services.BuildServiceProvider();

        using (var context = serviceProvider.GetRequiredService<AppDbContext>())
        {
            Console.WriteLine("Connected to the Database!");
        }
    }
}