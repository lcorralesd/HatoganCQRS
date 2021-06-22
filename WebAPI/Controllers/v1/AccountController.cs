using Application.DTOs.Users;
using Application.Features.Authenticate.Commands.AuthenticateCommand;
using Application.Features.Authenticate.Commands.RegisterCommand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class AccountController : BaseAPIController
    {

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticationRequest authenticationRequest)
        {
            return Ok(await Mediator.Send(new AuthenticateCommand
            {
                Email = authenticationRequest.Email,
                Password = authenticationRequest.Password,
                IpAddress = GenerateIpAddress()
            })); 
        }

        [HttpPost("register")]
        public async Task<IActionResult> Authenticate(RegisterRequest registerRequest)
        {
            return Ok(await Mediator.Send(new RegisterCommand
            {
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,
                Email = registerRequest.Email,
                UserName = registerRequest.UserName,
                Password = registerRequest.Password,
                ConfirmPassword = registerRequest.ConfirmPassword,
                Origin = Request.Headers["origin"]
            })); ;
        }

        private string GenerateIpAddress()
        {
            return Request.Headers.ContainsKey("X-Forwarded-For")
                ? Request.Headers["X-Forwarded-For"]
                : HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

        }
    }
}
