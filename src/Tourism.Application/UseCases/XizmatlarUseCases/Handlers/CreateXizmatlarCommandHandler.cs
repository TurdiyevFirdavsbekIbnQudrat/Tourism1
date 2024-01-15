using MediatR;
using Tourism.Application.Abstraction;
using Tourism.Application.UseCases.XizmatlarUseCases.Commands;
using Toursim.Domain.Entities;

namespace Tourism.Application.UseCases.XizmatlarUseCases.Handlers
{
    public class CreateXizmatlarCommandHandler : IRequestHandler<CreateXizmatlarCommand, Xizmatlar>
    {
        private readonly ITourismDbContext _tourism;

        public CreateXizmatlarCommandHandler(ITourismDbContext tourism)
        {
            _tourism = tourism;
        }

        public async Task<Xizmatlar> Handle(CreateXizmatlarCommand request, CancellationToken cancellationToken)
        {
            var command = new Xizmatlar()
            {
                nomi = request.nomi,
                rasm = request.rasm,
                shaharId = request.shaharId,
                boshlanishVaqti = request.boshlanishVaqti,
                haqida = request.haqida,
                kun = request.kun,
                narxi = request.narxi,
                tugashVaqti = request.tugashVaqti,

            };
            try
            {
                await _tourism.xizmatlar.AddAsync(command);
                _tourism.SaveChangesAsync(cancellationToken);
                return command;
            }
            catch
            {
                return new Xizmatlar();
            }

        }
    }
}
