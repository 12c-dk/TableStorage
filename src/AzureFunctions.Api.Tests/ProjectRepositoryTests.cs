using AzureFunctions.Api.Repositories;
using AzureFunctions.Api.Tests.Mocks;
using Microsoft.Extensions.Logging;
using Xunit;
using Xunit.Abstractions;

namespace AzureFunctions.Api.Tests
{
    public class ProjectRepositoryTests
    {
        private readonly ProjectRepository _projectFake;
        private readonly TestDataModel _testDataModel;
        private MockLogger<ProjectRepositoryTests> _log;

        public ProjectRepositoryTests(ProjectRepository projectFake, TestDataModel testDataModel, ITestOutputHelper output)
        {
            _projectFake = projectFake;
            _testDataModel = testDataModel;
            _log = new MockLogger<ProjectRepositoryTests>(output);
        }

        [Fact]
        public async void DeleteProject()
        {
            //Arrange
            //ProjectRepository (_projectFake) has two test projects, A01 and A02 seeded on initialization. 
            
            //Act
            await _projectFake.DeleteProject("A02");

            _log.LogInformation($"Project count after delete: {_testDataModel.Projects.Count}");
            
            //Assert
            Assert.Equal(1, _testDataModel?.Projects.Count);
        }
        
    }
}
