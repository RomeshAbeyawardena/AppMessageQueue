using AppMessageQueue.Domains.Dto;
using AppMessageQueue.Domains.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMessageQueue.Domains.Request
{
    public class RegisterUserRequest : IRequest<RegisterUserResponse>
    {
        public User User { get; set; }
    }
}
