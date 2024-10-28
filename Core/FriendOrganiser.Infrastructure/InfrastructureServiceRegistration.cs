
using FriendOrganiser.Application.Contracts.Infrastructure;
using FriendOrganiser.Infrastructure.FileExport;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FriendOrganiser.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
                services.AddTransient<ICsvExporter, CsvExporter>();
                return services;
        }
    }
}