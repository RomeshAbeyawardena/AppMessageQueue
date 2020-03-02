using AppMessageQueue.Services;
using DNI.Shared.Services.Abstraction;
using DataServiceRegistration = AppMessageQueue.Data.ServiceRegistration;

namespace AppMessageQueue.Broker
{
    public class ServiceBroker : ServiceBrokerBase
    {
        public ServiceBroker()
        {
            this.Assemblies = new [] { DefaultAssembly, GetAssembly<ServiceRegistration>(), GetAssembly<DataServiceRegistration>()  };
        }
    }
}
