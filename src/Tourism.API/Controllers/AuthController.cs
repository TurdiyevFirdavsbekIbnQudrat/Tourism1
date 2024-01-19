using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tourism.Application.Abstraction;
using Tourism.Application.UseCases.JwtAutUseCases.Command;

namespace Tourism.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public AuthController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async ValueTask<IActionResult> GetToken(JwtCheckCommand request)
        {
            var checkRole = await _mediatr.Send(request);
            if (!checkRole.Equals("mavjud emas!!!"))
            {
                JwtCommand command = new JwtCommand()
                {
                    email = request.email,
                    role = checkRole
                };
                var d = await _mediatr.Send(command);
                return Ok(d);
            }

                //JwtCommand request = new JwtCommand()
                //{
                //    username = email,
                //    parol = parol,
                //};
           //if(!d.Equals("mavjud emas!!!"))
           // {
           //     return Ok(d);
           // }
            return Ok("mavjud emas!!!");
        }
      
    }
}
