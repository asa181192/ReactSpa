using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SpaModel.Identity;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaService.Security
{
    public class Login
    {


        public class User : IRequest<string>
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class UserHandler : IRequestHandler<User, string>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly SignInManager<ApplicationUser> _signInManager;
            private readonly IConfiguration _configuration;

            public UserHandler(UserManager<ApplicationUser> userManager,
                SignInManager<ApplicationUser> signInManager,
                IConfiguration configuration
                )
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _configuration = configuration;
            }

            private string GenerateWebToken(ApplicationUser user)
            {
                var secretKey = _configuration.GetValue<string>("SecretKey");
                var key = Encoding.ASCII.GetBytes(secretKey);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Name, user.FirstName),
                        new Claim(ClaimTypes.Surname, user.LastName),
                        new Claim(ClaimTypes.NameIdentifier, user.UserName),
                        new Claim(ClaimTypes.Email, user.Email)                    
                    }),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(createdToken);
            }

            public async Task<string> Handle(User request, CancellationToken cancellationToken)
            {
                var usuario = await _userManager.FindByNameAsync(request.Email);
                if (usuario == null)
                {
                    throw new Exception("User doesnt exists");
                }

                var result = await _signInManager.CheckPasswordSignInAsync(usuario, request.Password, false);

                if (result.Succeeded)
                {
                    return GenerateWebToken(usuario);
                }

                throw new Exception("error with password");

            }


        }
    }
}
