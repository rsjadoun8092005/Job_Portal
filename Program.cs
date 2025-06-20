using System;
using Job_Portal.models;
using Job_Portal.models.enums;

class Program
{
    static void Main(string[] args)
    {
        User user1 = new User
        {
            Id = 1,
            Name = "Raghvendra",
            Email = "rsjadoun8092005@gmail.com",
            Role = UserRole.JobSeeker
        };

        Job job1 = new Job
        {
            Id = 101,
            Title = "Backend Developer",
            Description = "Work on .Net Backend systems",
            CompanyName = "CodeArrest",
            Location = "Kota",
            PostedDate = DateTime.Now,
            ApplicationsCount = 0,
            PostedBy = user1.Id,
            Type = JobType.Internship
        };

        Application app1 = new Application
        {
            Id = 1001,
            JobId = job1.Id,
            UserId = user1.Id,
            ApplicationDate = DateTime.Now,
            Status = ApplicationStatus.Pending
        };
        Console.WriteLine($"User: {user1.Name} applied to job: {job1.Title} at {job1.CompanyName} on {app1.ApplicationDate}. Current status: {app1.Status}");
    }
}