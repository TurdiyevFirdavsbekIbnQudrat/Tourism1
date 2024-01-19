using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tourism.API.Addictional.RasmUchun;
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
        private readonly IRasmPlace _rasmp;

        public ShaharController(IMediator _mediator, IRasmPlace rasmp)
        {
            mediator = _mediator;
            _rasmp = rasmp;
        }
        [Authorize(Roles = "admin")]
        //    [Authorize(Roles = "Admin")]
        [HttpPost]
        public async ValueTask<IActionResult> CreateShaharlarAsync([FromForm] CreateShaharDto command)
        {
            CreateShaharlarCommand request = new CreateShaharlarCommand()
            {
                rasm = await _rasmp.GetRasm(command.rasm),
                nomi = command.nomi
            };
            var result = await mediator.Send(request);
            return Ok(result);
        }
        //  [Authorize(Roles = "Admin")]

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllShaharlarAsync()
        {
            return Ok(await mediator.Send(new GetAllShaharlarCommand()));
        }

        //[Authorize(Roles = "Admin")]

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async ValueTask<IActionResult> GetShaharlarByIdAsync(int id)
        {
            GetByIdFoydalanuvchiCommand command = new GetByIdFoydalanuvchiCommand { id = id };
            return Ok(await mediator.Send(command));
        }

        //[Authorize(Roles = "Admin")]

        [Authorize(Roles = "admin")]
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteShaharlarById(int id)
        {
            DeleteShaharlarCommand command = new DeleteShaharlarCommand() { id = id };
            return Ok(await mediator.Send(command));
        }

        //[Authorize(Roles = "Admin")]

        [Authorize(Roles = "admin")]
        [HttpPut]
        public async ValueTask<IActionResult> UpdateShaharlarById(UpdateShaharDto command, int id)
        {
            UpdateShaharlarCommand request = new UpdateShaharlarCommand()
            {
                nomi = command.nomi,
                rasm = await _rasmp.GetRasm(command.rasm),
                id = id,
            };
            return Ok(await mediator.Send(request));
        }
    }
}
