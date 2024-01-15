using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tourism.API.Dtos.XizmatlarDto;
using Tourism.Application.UseCases.XizmatlarUseCases.Commands;
using Tourism.Application.UseCases.XizmatlarUseCases.Queries;

namespace Tourism.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class XizmatlarController : ControllerBase
    {
        private readonly IMediator mediator;

        public XizmatlarController(IMediator _mediator)
        {
            mediator = _mediator;
        }
        //    [Authorize(Roles = "Admin")]
        [HttpPost]
        public async ValueTask<IActionResult> CreateXizmatlarAsync(CreateXizmatlarCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
        //  [Authorize(Roles = "Admin")]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllXizmatlarAsync()
        {
            return Ok(await mediator.Send(new GetAllXizmatlarCommand()));
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public async ValueTask<IActionResult> GetXizmatlarByIdAsync(int id)
        {
            GetByIdXizmatlarCommand command = new GetByIdXizmatlarCommand { id = id };
            return Ok(await mediator.Send(command));
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteXizmatlarById(int id)
        {
            DeleteXizmatlarCommand command = new DeleteXizmatlarCommand() { id = id };
            return Ok(await mediator.Send(command));
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut]
        public async ValueTask<IActionResult> UpdateXizmatlarById(UpdateXizmatlarDto request, int id)
        {
            UpdateXizmatlarCommand command = new UpdateXizmatlarCommand()
            {
                nomi = request.nomi,
                rasm = request.rasm,
                shaharId = request.shaharId,
                boshlanishVaqti = request.boshlanishVaqti,
                haqida = request.haqida,
                kun = request.kun,
                narxi = request.narxi,
                tugashVaqti = request.tugashVaqti,
                id = id,
            };
            return Ok(await mediator.Send(command));
        }
    }
}
