using AppMessageQueue.Domains.Data;
using AppMessageQueue.Services;
using DNI.Shared.Contracts;
using DNI.Shared.Contracts.Options;
using DNI.Shared.Services.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AppMessageQueue.Data
{
    public class ServiceRegistration : IServiceRegistration
    {
        public void RegisterServices(IServiceCollection services, IServiceRegistrationOptions options)
        {
            services
                .AddDbContext<AppIdentityDbContext>()
                .RegisterDbContentRepositories<AppIdentityDbContext>(ServiceLifetime.Transient, 
                    typeof(ApplicationInstance), 
                    typeof(User));
        }
    }
}
