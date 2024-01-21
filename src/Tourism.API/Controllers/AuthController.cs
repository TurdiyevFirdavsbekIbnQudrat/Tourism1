using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tourism.API.Dtos.AuthDto;
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
            string d = "";
            if (!checkRole.Equals("mavjud emas!!!"))
            {
                JwtCommand command = new JwtCommand()
                {
                    email = request.email,
                    role = checkRole
                };
                 d = await _mediatr.Send(command);
                
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
            AuthDto auth = new AuthDto()
            {
                token = d
            };
            if (!auth.Equals("mavjud emas!!!"))
            {
                return Ok(auth);
            }
            return BadRequest("mavjud emas!!!");
        }

    }
}
