using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpaModel.Identity;
using SpaService.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Unit>> Create(Create.User model)
        {
            return await _mediator.Send(new Create.User()
            {
                FirstName= model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password
            });
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(Login.User model)
        {
            return await _mediator.Send(new Login.User()
            {
                Email = model.Email,
                Password = model.Password
            });
        }
    }
}
