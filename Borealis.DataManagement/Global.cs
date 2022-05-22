global using System.Text.Json;
global using Microsoft.Azure.Cosmos;
global using MudBlazor;
global using MudBlazor.Services;
global using Borealis.DataManagement.Models;
global using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace Borealis.DataManagement
{
    public static class Global
    {
        public static void AddDataServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(ICosmosService), typeof(CosmosService));
            services.AddScoped(typeof(CosmosRepository<>));
        }
    }
}
