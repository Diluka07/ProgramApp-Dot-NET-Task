using Microsoft.Azure.Cosmos;
using WebApplicationDotNET_Task.Models;

namespace WebApplicationDotNET_Task.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly CosmosClient cosmosClient;
        private readonly IConfiguration configuration;
        private readonly Container _programContainer;

        public ApplicationService(CosmosClient cosmosClient, IConfiguration configuration)
        {
            this.cosmosClient = cosmosClient;
            this.configuration = configuration;
            var databaseId = configuration["CosmosDbSettings:DatabaseId"];
            var programContainerName = "programs";
            _programContainer = cosmosClient.GetContainer(databaseId, programContainerName);
        }
        public async Task CreatePogramApplication(ProgramModel program)
        {
            try
            {
                await _programContainer.CreateItemAsync(program);
            }
            catch
            {
                throw;
            }
        }
    }
}
