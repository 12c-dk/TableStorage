using AzureFunctions.Api;
using AzureFunctions.Api.Helpers;
using AzureFunctions.Api.Managers;
using AzureFunctions.Api.Repositories;
//using Microsoft.Azure.Functions.Extensions;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;


[assembly: FunctionsStartup(typeof(Startup))]
namespace AzureFunctions.Api
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            ConfigManager configManager = new ConfigManager();

            var services = builder.Services;
            
            services.AddSingleton(configManager);
            services.AddSingleton<FunctionHelper>();
            services.AddSingleton<ProjectRepository>();
            services.BuildServiceProvider();
            
        }
    }

}
