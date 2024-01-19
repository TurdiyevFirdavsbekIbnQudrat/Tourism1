using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tourism.Application.UseCases.JwtAutUseCases.Command;

namespace Tourism.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediatr;
        [HttpGet]
        public async ValueTask<IActionResult> GetToken(string username,string role)
        {
            JwtCommand request = new JwtCommand()
            {
                username = username,
                role = role,
            };
            return Ok(await _mediatr.Send(request));
        }
    }
}
