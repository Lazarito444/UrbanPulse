using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UrbanPulse.Domain.Common.Repositories;
using UrbanPulse.Infrastructure.Contexts;
using UrbanPulse.Infrastructure.Repositories;

namespace UrbanPulse.Infrastructure.Extensions;

public static class IServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection SetupInfrastructure(string connectionString)
        {
            services.SetupDbContext(connectionString);
            services.SetupDataRepository();
            return services;
        }

        private IServiceCollection SetupDbContext(string connectionString)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(connectionString);
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseNpgsql(connectionString);
            });
            return services;
        }

        private IServiceCollection SetupDataRepository()
        {
            services.AddScoped(typeof(IRepository<>), typeof(DataRepository<>));
            return services;
        }
    }
}
