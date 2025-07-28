using Moq;
using Xunit;
using Job_Portal.models;
using Job_Portal.Services.Implementations;
using Job_Portal.Repositories.Interfaces;

namespace Job_Portal.Tests;

public class JobServiceTests
{
    [Fact]
    public async Task GetJobByIdAsync_ShouldReturnJob_WhenJobExists()
    {
        var expectedJob = new Job { Id = 1, Title = "Software Engineer" };

        var mockRepository = new Mock<IJobRepository>();

        mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(expectedJob);

        var jobService = new JobService(mockRepository.Object);

        var result = await jobService.GetJobByIdAsync(1);

        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("Software Engineer", result.Title);
    }
}
