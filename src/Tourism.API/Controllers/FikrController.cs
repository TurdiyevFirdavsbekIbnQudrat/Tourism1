using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tourism.API.Dtos.FikrDto;
using Tourism.Application.UseCases.FikrUseCases.Commands;
using Tourism.Application.UseCases.FikrUseCases.Queries;

namespace Tourism.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FikrController : ControllerBase
    {
        private readonly IMediator mediator;

        public FikrController(IMediator _mediator)
        {
            mediator = _mediator;
        }
        //    [Authorize(Roles = "Admin")]

        [Authorize(Roles = "admin,foydalanuvchi")]
        [HttpPost]
        public async ValueTask<IActionResult> CreateFikrAsync(CreateFikrCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
        //  [Authorize(Roles = "Admin")]

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllFikrAsync()
        {
            return Ok(await mediator.Send(new GetAllFikrCommand()));
        }

        //[Authorize(Roles = "Admin")]
        [Authorize(Roles = "admin")]
        [HttpGet]

        public async ValueTask<IActionResult> GetFikrByIdAsync(int id)
        {
            GetByIdFikrCommand command = new GetByIdFikrCommand { id = id };
            return Ok(await mediator.Send(command));
        }

        //[Authorize(Roles = "Admin")]

        [Authorize(Roles = "admin")]
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteFikrById(int id)
        {
            DeleteFikrCommand command = new DeleteFikrCommand() { id = id };
            return Ok(await mediator.Send(command));
        }

        //[Authorize(Roles = "Admin")]

        [Authorize(Roles = "admin")]
        [HttpPut]
        public async ValueTask<IActionResult> UpdateFikrById(UpdateFikrDto request, int id)
        {
            UpdateFikrCommand command = new UpdateFikrCommand()
            {
                foydalanunchiId = request.foydalanunchiId,
                foydalanuvchiFikr = request.foydalanuvchiFikr,
                id = id,
            };
            return Ok(await mediator.Send(command));
        }
    }
}
