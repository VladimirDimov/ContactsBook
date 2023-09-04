using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ContactsBook.Application.Contracts.Persistence;
using ContactsBook.Persistence.DatabaseContext;
using ContactsBook.Persistence.Repositories;
using ContactsBook.Domain.Interfaces;
using ContactsBook.Persistence.DomainEvents;
using ContactsBook.Persistence.EventHandlers;
using ContactsBook.Domain.Events;

namespace ContactsBook.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContactsBookDatabaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ContactsBook"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IContactRepository), typeof(ContactRepository));
            services.AddScoped(typeof(IAddressRepository), typeof(AddressRepository));

            services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

            services.AddScoped<IHandle<AddressAddedEvent>, AddressAddedEventHandler>();
            services.AddScoped<IHandle<AddressDeletedEvent>, AddressDeletedEventHandler>();
            services.AddScoped<IHandle<AddressUpdatedEvent>, AddressUpdatedEventHandler>();

            return services;
        }
    }
}
