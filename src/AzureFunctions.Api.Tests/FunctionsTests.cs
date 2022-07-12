using AzureFunctions.Api.Tests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using AzureFunctions.Api.Helpers;
using AzureFunctions.Api.Model;
using AzureFunctions.Api.Repositories;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace AzureFunctions.Api.Tests
{
    public class FunctionsTests
    {
        readonly MockLogger<FunctionsTests> _mockLogger;
        readonly FunctionHelper _functionHelper;
        private readonly ProjectRepository _projectRepository;

        public FunctionsTests(ITestOutputHelper output, FunctionHelper functionHelper, ProjectRepository projectRepository)
        {
            _mockLogger = new MockLogger<FunctionsTests>(output);
            _functionHelper = functionHelper;
            _projectRepository = projectRepository;
        }

        [Fact]
        public void GetProjectTest()
        {
            _mockLogger.LogInformation("GetProjectTest started");

            //Arrange
            string body = File.ReadAllText("Samples\\ProjectGetRequest.json");
            var req = HttpMock.HttpRequestSetup(body);
            var func = new Functions.GetProject(_functionHelper, _projectRepository);

            //Act
            var result = func.Run(req, _mockLogger).Result;

            //assert
            OkObjectResult res = (OkObjectResult)result;
            string outputStr = JsonConvert.SerializeObject(res.Value);
            Assert.False(string.IsNullOrEmpty(outputStr));
            Assert.Contains("Skagens perle", outputStr);

        }

        [Fact]
        public void UpsertProjectTest()
        {
            _mockLogger.LogInformation("UpsertProjectTest started");

            //Arrange
            Project upsertProject = new Project()
            {
                ProjectId = "A02",
                Title = "Upsert test"
            };
            string body = JsonConvert.SerializeObject(upsertProject);
            var req = HttpMock.HttpRequestSetup(body);
            var func = new Functions.UpsertProject(_functionHelper,_projectRepository);

            //Act
            var result = func.Run(req, _mockLogger).Result;

            //Assert
            OkObjectResult res = (OkObjectResult)result;
            string outputStr = JsonConvert.SerializeObject(res.Value);
            Assert.False(string.IsNullOrEmpty(outputStr));
            Assert.Contains("Upsert test", outputStr);

        }

    }
}
