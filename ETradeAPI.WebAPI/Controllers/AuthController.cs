using ETradeAPI.Application.Features.Auths.Commands;
using ETradeAPI.Core.Security.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController

    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            var registerCommand = new RegisterCommand() { UserForRegisterDto = userForRegisterDto };
            var result = await Mediator.Send(registerCommand);
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            var loginCommand = new LoginCommand() { UserForLoginDto = userForLoginDto };
            var result = await Mediator.Send(loginCommand);
            return Ok(result);
        }
    }
}
