using AppMessageQueue.Domains.ViewModels;
using DNI.Shared.Services.Abstraction;
using AppMessageQueue.Domains.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatorResponse = DNI.Shared.Domains.Response;

namespace AppMessageQueue.Web.Controllers
{
    public class ApplicationController : DefaultApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Create(CreateApplicationInstanceViewModel model)
        {
            var request = Map<CreateApplicationInstanceViewModel, 
                RegisterApplicationInstanceRequest>(model);

            var response = await MediatorService.Send(request);

            if(MediatorResponse.IsSuccessful(response))
                return Ok(response.Result);

            return BadRequest(response.Errors);
        }
    }
}
