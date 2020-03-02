using AppMessageQueue.Contracts;
using DNI.Shared.Contracts;
using DNI.Shared.Contracts.Options;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AppMessageQueue.Services
{
    public class ServiceRegistration : IServiceRegistration
    {
        public void RegisterServices(IServiceCollection services, IServiceRegistrationOptions options)
        {
            services
                .AddTransient<IUserService, UserService>()
                .AddTransient<IApplicationInstanceService, ApplicationInstanceService>();
        }
    }
}
