using System.Reflection;
using ContactsBook.Application.Behaviors;
using ContactsBook.Application.Common.Helpers;
using ContactsBook.Application.Contracts.Helpers;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ContactsBook.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddSingleton<IIbanHelper, IbanHelper>();

            return services;
        }
    }
}
