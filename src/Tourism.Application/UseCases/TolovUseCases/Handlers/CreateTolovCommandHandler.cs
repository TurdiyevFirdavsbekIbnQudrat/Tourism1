using MediatR;
using Tourism.Application.Abstraction;
using Tourism.Application.UseCases.TolovUseCases.Commands;
using Toursim.Domain.Entities;

namespace Tourism.Application.UseCases.TolovUseCases.Handlers
{
    public class CreateTolovCommandHandler : IRequestHandler<CreateTolovCommand, Tolov>
    {
        private readonly ITourismDbContext _tourism;

        public CreateTolovCommandHandler(ITourismDbContext tourism)
        {
            _tourism = tourism;
        }

        public async Task<Tolov> Handle(CreateTolovCommand request, CancellationToken cancellationToken)
        {
            var command = new Tolov()
            {
                foydalanuvchiId = request.foydalanuvchiId,
                tolovQiymati = request.tolovQiymati
            };
            try
            {
                await _tourism.tolovlar.AddAsync(command);
                _tourism.SaveChangesAsync(cancellationToken);
                return command;
            }
            catch
            {
                return new Tolov();
            }

        }
    }
}
