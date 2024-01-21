using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tourism.API.Addictional.RasmUchun;
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
        private readonly IRasmPlace _rasmp;

        public XizmatlarController(IMediator _mediator, IRasmPlace rasmp)
        {
            mediator = _mediator;
            _rasmp = rasmp;
        }
        //    [Authorize(Roles = "Admin")]

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async ValueTask<IActionResult> CreateXizmatlarAsync(CreateXizmatDto request)
        {
            CreateXizmatlarCommand command = new CreateXizmatlarCommand()
            {
                nomi = request.nomi,
                rasm = await _rasmp.GetRasm(request.rasm),
                shaharId = request.shaharId,
                boshlanishVaqti = request.boshlanishVaqti,
                haqida = request.haqida,
                kun = request.kun,
                narxi = request.narxi,
                tugashVaqti = request.tugashVaqti,

            };
            var result = await mediator.Send(command);
            return Ok(result);
        }
        //  [Authorize(Roles = "Admin")]

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllXizmatlarAsync()
        {
            return Ok(await mediator.Send(new GetAllXizmatlarCommand()));
        }

        //[Authorize(Roles = "Admin")]

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async ValueTask<IActionResult> GetXizmatlarByIdAsync(int id)
        {
            GetByIdXizmatlarCommand command = new GetByIdXizmatlarCommand { id = id };
            return Ok(await mediator.Send(command));
        }

        //[Authorize(Roles = "Admin")]

        [Authorize(Roles = "admin")]
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteXizmatlarById(int id)
        {
            DeleteXizmatlarCommand command = new DeleteXizmatlarCommand() { id = id };
            return Ok(await mediator.Send(command));
        }

        //[Authorize(Roles = "Admin")]

        [Authorize(Roles = "admin")]
        [HttpPut]
        public async ValueTask<IActionResult> UpdateXizmatlarById(UpdateXizmatlarDto request, int id)
        {
            UpdateXizmatlarCommand command = new UpdateXizmatlarCommand()
            {
                nomi = request.nomi,
                rasm = await _rasmp.GetRasm(request.rasm),
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
