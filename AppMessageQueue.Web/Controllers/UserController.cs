using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMessageQueue.Domains.Request;
using AppMessageQueue.Domains.Response;
using AppMessageQueue.Domains.ViewModels;
using DNI.Shared.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using MediatorResponse = DNI.Shared.Domains.Response;

namespace AppMessageQueue.Web.Controllers
{
    public class UserController : DefaultApiControllerBase
    {
        
        [HttpPost]
        public async Task<ActionResult> Register([FromForm]RegisterViewModel model)
        {
            var request = Map<RegisterViewModel, RegisterUserRequest>(model);

            var response = await MediatorService.Send(request);

            if(MediatorResponse.IsSuccessful(response))
                return Ok(response.Result);

            return BadRequest(response.Errors);
        }
    }
}
