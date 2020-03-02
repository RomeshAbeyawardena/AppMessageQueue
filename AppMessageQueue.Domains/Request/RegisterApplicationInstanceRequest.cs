using AppMessageQueue.Domains.Data;
using AppMessageQueue.Domains.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMessageQueue.Domains.Request
{
    public class RegisterApplicationInstanceRequest : IRequest<RegisterApplicationInstanceResponse>
    {
        public ApplicationInstance ApplicationInstance { get; set; }
    }
}
