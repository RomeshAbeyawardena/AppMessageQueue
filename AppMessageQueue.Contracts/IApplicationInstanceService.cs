using AppMessageQueue.Domains.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppMessageQueue.Contracts
{
    public interface IApplicationInstanceService
    {
        Task<ApplicationInstance> GetByInstanceId(Guid applicationInstance, CancellationToken cancellationToken);
        Task<ApplicationInstance> Save(ApplicationInstance applicationInstance, CancellationToken cancellationToken);
    }
}
