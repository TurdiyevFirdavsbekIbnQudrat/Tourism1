using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tourism.API.Dtos.ShaharDto;
using Tourism.Application.UseCases.FoydalanuvchiUseCases.Queries;
using Tourism.Application.UseCases.ShaharlarUseCases.Commands;
using Tourism.Application.UseCases.ShaharlarUseCases.Queries;

namespace Tourism.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShaharController : ControllerBase
    {
        private readonly IMediator mediator;

        public ShaharController(IMediator _mediator)
        {
            mediator = _mediator;
        }
        //    [Authorize(Roles = "Admin")]
        [HttpPost]
        public async ValueTask<IActionResult> CreateShaharlarAsync(CreateShaharlarCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
        //  [Authorize(Roles = "Admin")]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllShaharlarAsync()
        {
            return Ok(await mediator.Send(new GetAllShaharlarCommand()));
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public async ValueTask<IActionResult> GetShaharlarByIdAsync(int id)
        {
            GetByIdFoydalanuvchiCommand command = new GetByIdFoydalanuvchiCommand { id = id };
            return Ok(await mediator.Send(command));
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteShaharlarById(int id)
        {
            DeleteShaharlarCommand command = new DeleteShaharlarCommand() { id = id };
            return Ok(await mediator.Send(command));
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut]
        public async ValueTask<IActionResult> UpdateShaharlarById(UpdateShaharDto request, int id)
        {
            UpdateShaharlarCommand command = new UpdateShaharlarCommand()
            {
                nomi = request.nomi,
                rasm = request.rasm,
                id = id,
            };
            return Ok(await mediator.Send(command));
        }
    }
}
