using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WeeloApi.Application.Common.Exceptions;
using WeeloApi.Infrastructure.Identity;
using WeeloApi.WebUI.Models;

namespace WeeloApi.WebUI.Controllers.v1
{
    public class AuthController : ApiControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public AuthController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
        }
        [HttpPost()]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginUserModel request)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(request.Username,
                           request.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var claims = new[] {
                        new Claim(ClaimTypes.NameIdentifier, request.Username),
                        new Claim(JwtRegisteredClaimNames.Jti, 
                        Guid.NewGuid().ToString())
                    };
                    var signingkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JwT_Secret"].ToString()));
                    var token = new JwtSecurityToken(
                        issuer: Configuration["ApplicationSettings:Client_URL"].ToString(),
                        audience: Configuration["ApplicationSettings:Client_URL"].ToString(),
                        claims: claims,
                        expires: DateTime.UtcNow.AddHours(24),
                        signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signingkey, SecurityAlgorithms.HmacSha256)
                    );
                    return Ok(new
                    {
                        AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                        ExpirationToken = token.ValidTo
                });
                }
                return Unauthorized(ModelState);
            }
            else
            {
                return Unauthorized(ModelState);
            }

        }
    }
}
