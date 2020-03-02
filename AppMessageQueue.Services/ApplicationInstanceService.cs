using AppMessageQueue.Contracts;
using AppMessageQueue.Domains.Data;
using DNI.Shared.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppMessageQueue.Services
{
    public class ApplicationInstanceService : IApplicationInstanceService
    {
        private readonly IRepository<ApplicationInstance> _applicationInstanceRepository;
        private IQueryable<ApplicationInstance> DefaultQuery => _applicationInstanceRepository
            .Query(applicationInstance => applicationInstance.Active, false);
        public async Task<ApplicationInstance> GetByInstanceId(Guid applicationInstanceGuid, CancellationToken cancellationToken)
        {
            var query = from applicationInstance in DefaultQuery
                        where applicationInstance.InstanceId == applicationInstanceGuid
                        select applicationInstance;

            return await query.SingleOrDefaultAsync();
        }

        public async Task<ApplicationInstance> Save(ApplicationInstance applicationInstance, CancellationToken cancellationToken)
        {
            return await _applicationInstanceRepository
                .SaveChanges(applicationInstance, cancellationToken: cancellationToken);
        }

        public ApplicationInstanceService(IRepository<ApplicationInstance> applicationInstanceRepository)
        {
            _applicationInstanceRepository = applicationInstanceRepository;
        }
    }
}
