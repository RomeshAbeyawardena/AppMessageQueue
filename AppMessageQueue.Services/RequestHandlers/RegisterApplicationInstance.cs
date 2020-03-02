using AppMessageQueue.Contracts;
using AppMessageQueue.Domains.Request;
using AppMessageQueue.Domains.Response;
using DNI.Shared.Domains;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppMessageQueue.Services.RequestHandlers
{
    public class RegisterApplicationInstance : IRequestHandler<RegisterApplicationInstanceRequest, RegisterApplicationInstanceResponse>
    {
        private readonly IApplicationInstanceService _applicationInstanceService;

        public async Task<RegisterApplicationInstanceResponse> Handle(RegisterApplicationInstanceRequest request, CancellationToken cancellationToken)
        {
            var applicationInstance = await _applicationInstanceService
                .GetByInstanceId(request.ApplicationInstance.InstanceId, cancellationToken);

            if(applicationInstance != null)
                return Response.Failed<RegisterApplicationInstanceResponse>(new ValidationFailure(
                    nameof(request.ApplicationInstance.InstanceId), $"{request.ApplicationInstance.InstanceId} already exists."));

            var savedApplicationInstance = await _applicationInstanceService.Save(request.ApplicationInstance, cancellationToken);

            return Response.Success<RegisterApplicationInstanceResponse>(savedApplicationInstance);
        }

        public RegisterApplicationInstance(IApplicationInstanceService applicationInstanceService)
        {
            _applicationInstanceService = applicationInstanceService;
        }
    }
}
