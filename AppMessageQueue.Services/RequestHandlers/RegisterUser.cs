using AppMessageQueue.Contracts;
using AppMessageQueue.Domains.Data;
using AppMessageQueue.Domains.Request;
using AppMessageQueue.Domains.Response;
using DNI.Shared.Contracts.Providers;
using DNI.Shared.Domains;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserDto = AppMessageQueue.Domains.Dto.User;

namespace AppMessageQueue.Services.RequestHandlers
{
    public class RegisterUser : IRequestHandler<RegisterUserRequest, RegisterUserResponse>
    {
        private readonly IApplicationInstanceService _applicationInstanceService;
        private readonly IEncryptionProvider _encryptionProvider;
        private readonly IUserService _userService;

        public async Task<RegisterUserResponse> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            User foundUser;
            if (request.User.Id == default 
                || (await _userService.Get(request.User.Id, cancellationToken)) == null)
                return Response.Failed<RegisterUserResponse>(new ValidationFailure(
                    nameof(request.User.Id), $"User with '{request.User.Id}' not found"));
            
            var encryptedUser = await _encryptionProvider.Encrypt<UserDto, User>(request.User);

            foundUser = await _userService
                .GetByEmailAddress(request.User.ApplicationInstance, encryptedUser.EmailAddress, cancellationToken);
            
            if(foundUser != null 
                && request.User.Id != default 
                && foundUser.Id != request.User.Id)
                return Response.Failed<RegisterUserResponse>(new ValidationFailure(
                    nameof(request.User.EmailAddress), $"User with '{request.User.EmailAddress}' not found"));

            if(await _applicationInstanceService.GetByInstanceId(request.User.ApplicationInstance, cancellationToken) == null)
                return Response.Failed<RegisterUserResponse>(new ValidationFailure(nameof(request.User.ApplicationInstance),
                    $"Application instance '{request.User.ApplicationInstance}' not found"));
            var savedUser = await _userService.Save(encryptedUser, cancellationToken);
            var decryptedUser = await _encryptionProvider.Decrypt<User, UserDto>(savedUser);
            return Response.Success<RegisterUserResponse>(decryptedUser);
        }

        public RegisterUser(IApplicationInstanceService applicationInstanceService, 
            IEncryptionProvider encryptionProvider, IUserService userService)
        {
            _applicationInstanceService = applicationInstanceService;
            _encryptionProvider = encryptionProvider;
            _userService = userService;
        }
    }
}
