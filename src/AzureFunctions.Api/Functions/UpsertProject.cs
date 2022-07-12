using System.Threading.Tasks;
using AzureFunctions.Api.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AzureFunctions.Api.Model;
using AzureFunctions.Api.Repositories;

namespace AzureFunctions.Api.Functions
{
    public class UpsertProject
    {
        private readonly FunctionHelper _functionHelper;
        private ProjectRepository _projectRepository;

        public UpsertProject(FunctionHelper functionHelper, ProjectRepository projectRepository)
        {
            _functionHelper = functionHelper;
            _projectRepository = projectRepository;
        }

        [FunctionName("UpsertProject")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("UpsertProject called");

            Project projectRequest = await _functionHelper.DeserializeBody<Project>("CreateProject", req);
            projectRequest.RowKey = projectRequest.ProjectId;

            var newProject = await _projectRepository.CreateProject(projectRequest);

            return new OkObjectResult(newProject);
        }
    }
}
