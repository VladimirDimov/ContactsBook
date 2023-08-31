using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeopleCatalogue.Application.Contracts.Persistence;
using PeopleCatalogue.Persistence.DatabaseContext;
using PeopleCatalogue.Persistence.Repositories;

namespace PeopleCatalogue.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PeopleDatabaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("PeopleCatalogue"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
