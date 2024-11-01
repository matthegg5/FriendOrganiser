#pragma warning disable CS8604 

using FriendOrganiser.Application.Contracts.Persistence;
using FriendOrganiser.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FriendOrganiser.Infrastructure.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FriendOrganiserDbContext>(options => options.UseMySQL(configuration.GetConnectionString("FriendOrganiserDbConnectionString")));
 
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IFriendRepository, FriendRepository>();

            return services;
        }
    }
}