using MediatR;
using Microsoft.AspNetCore.Identity;
using SpaModel.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaService.Security
{
    public class Create
    {
        public class User : IRequest
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class UserHandler : IRequestHandler<User>
        {
            private readonly UserManager<ApplicationUser> _userManager;

            public UserHandler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
            {
                _userManager = userManager;
            }

            public async Task<Unit> Handle(User request, CancellationToken cancellationToken)
            {
                var result = await _userManager.CreateAsync(
                    new ApplicationUser
                    {
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Email = request.Email,
                        UserName = request.Email
                    },
                    request.Password
                    );

                if (!result.Succeeded)
                {
                    throw new Exception("Error when create user");
                }

                return Unit.Value;


            }
        }
    }
}

