using AppMessageQueue.Domains.Data;
using AppMessageQueue.Domains.Request;
using AppMessageQueue.Domains.ViewModels;
using AutoMapper;
using System;

namespace AppMessageQueue.Domains
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<RegisterViewModel,RegisterUserRequest>()
                .ForMember(member => member.User, options => options
                .MapFrom(new RegisterViewModelUserDtoValueResolver()));

            CreateMap<Dto.User, User>()
                .ForMember(member => member.EmailAddress, options => options.Ignore())
                .ForMember(member => member.FirstName, options => options.Ignore())
                .ForMember(member => member.MiddleName, options => options.Ignore())
                .ForMember(member => member.LastName, options => options.Ignore());

            CreateMap<User, Dto.User>()
                .ForMember(member => member.EmailAddress, options => options.Ignore())
                .ForMember(member => member.FirstName, options => options.Ignore())
                .ForMember(member => member.MiddleName, options => options.Ignore())
                .ForMember(member => member.LastName, options => options.Ignore());

            CreateMap<CreateApplicationInstanceViewModel, RegisterApplicationInstanceRequest>()
                .ForMember(member => member.ApplicationInstance, options => options
                .MapFrom(new CreateApplicationInstanceViewModelApplicationInstanceResolver()));
        }
    }

    public class RegisterViewModelUserDtoValueResolver : IValueResolver<RegisterViewModel, RegisterUserRequest, Dto.User>
    {
        public Dto.User Resolve(RegisterViewModel source, RegisterUserRequest destination, 
                Dto.User destMember, ResolutionContext context)
        {
            return context.Mapper.Map<RegisterViewModel, Dto.User>(source);
        }
    }

    public class CreateApplicationInstanceViewModelApplicationInstanceResolver
        : IValueResolver<CreateApplicationInstanceViewModel, RegisterApplicationInstanceRequest, ApplicationInstance>
    {
        public ApplicationInstance Resolve(CreateApplicationInstanceViewModel source, 
            RegisterApplicationInstanceRequest destination, ApplicationInstance destMember, ResolutionContext context)
        {
            return context.Mapper.Map<CreateApplicationInstanceViewModel, 
                ApplicationInstance>(source);
        }
    }

}
