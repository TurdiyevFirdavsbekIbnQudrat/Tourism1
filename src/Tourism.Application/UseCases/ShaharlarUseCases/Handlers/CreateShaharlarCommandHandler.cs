using MediatR;
using Tourism.Application.Abstraction;
using Tourism.Application.UseCases.ShaharlarUseCases.Commands;
using Toursim.Domain.Entities;

namespace Tourism.Application.UseCases.ShaharlarUseCases.Handlers
{
    public class CreateShaharlarCommandHandler : IRequestHandler<CreateShaharlarCommand, Shahar>
    {
        private readonly ITourismDbContext _tourism;

        public CreateShaharlarCommandHandler(ITourismDbContext tourism)
        {
            _tourism = tourism;
        }

        public async Task<Shahar> Handle(CreateShaharlarCommand request, CancellationToken cancellationToken)
        {
            var command = new Shahar()
            {
                nomi = request.nomi,
                rasm = request.rasm
            };
            try
            {
                await _tourism.shaharlar.AddAsync(command);
                _tourism.SaveChangesAsync(cancellationToken);
                return command;
            }
            catch
            {
                return new Shahar();
            }

        }
    }

}
