using Microsoft.Azure.Cosmos;
using WebApplicationDotNET_Task.Services;

namespace WebApplicationDotNET_Task
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            // Add services to the container.
            builder.Services.AddSingleton((provider) =>
            {
                var endpointUri = configuration["CosmosDbSettings:EndpointUri"];
                var primaryKey = configuration["CosmosDbSettings:PrimaryKey"];
                var databaseId = configuration["CosmosDbSettings:DatabaseId"];

                var cosmosClientOptions = new CosmosClientOptions
                {
                    ApplicationName = databaseId
                };

                var cosmosClient = new CosmosClient(endpointUri, primaryKey, cosmosClientOptions);
                cosmosClient.ClientOptions.ConnectionMode = ConnectionMode.Direct;
                return cosmosClient;
            });

            builder.Services.AddScoped<IApplicationService, ApplicationService>();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
