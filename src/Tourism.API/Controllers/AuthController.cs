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
        private readonly ITourismDbContext _tourism;
        [HttpPost]
        public async ValueTask<IActionResult> GetToken(string email, string role)
        {
            if (role.Trim().ToLower().Equals("admin"))
            {
                var x = await _tourism.adminlar.FirstOrDefaultAsync(x => x.email == email);
                if (x == null)
                {
                    return Ok("ma'lumot topilmadi");
                }
                else
                {

                    return Ok(getToken(email, role));
                }
            }
            if (role.Trim().ToLower().Equals("foydalanuvchi"))
            {
                var x = await _tourism.foydalanuvchilar.FirstOrDefaultAsync(x => x.email == email);
                if (x == null)
                {
                    return Ok("ma'lumot topilmadi");
                }
                else
                {
                    return Ok(getToken(email, role));
                }
            }
            return Ok("bunday ma'lumot mavjud emas");
        }
        private async ValueTask<string> getToken(string username, string role)
        {

            JwtCommand request = new JwtCommand()
            {
                username = username,
                role = role,
            };
            return await _mediatr.Send(request);
        }
    }
}
