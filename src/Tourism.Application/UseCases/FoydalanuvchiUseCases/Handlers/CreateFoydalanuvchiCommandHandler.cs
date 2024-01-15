using MediatR;
using Tourism.Application.Abstraction;
using Tourism.Application.UseCases.FoydalanuvchiUseCases.Commands;
using Toursim.Domain.Entities;
using Toursim.Domain.Enums;

namespace Tourism.Application.UseCases.FoydalanuvchiUseCases.Handlers
{
    public class CreateFoydalanuvchiCommandHandler : IRequestHandler<CreateFoydalanuvchiCommand, Foydalanuvchi>
    {
        private readonly ITourismDbContext _tourism;

        public CreateFoydalanuvchiCommandHandler(ITourismDbContext tourism)
        {
            _tourism = tourism;
        }

        public async Task<Foydalanuvchi> Handle(CreateFoydalanuvchiCommand request, CancellationToken cancellationToken)
        {
            var command = new Foydalanuvchi()
            {
                ism = request.ism,
                condition = Condition.created,
                email = request.email,
                familiya = request.familiya,
                parol = request.parol,
                role = Role.foydalanuvchi,
                telNomer = request.telNomer,
            };
            try
            {
                await _tourism.foydalanuvchilar.AddAsync(command);
                _tourism.SaveChangesAsync(cancellationToken);
                return command;
            }
            catch
            {
                return new Foydalanuvchi();
            }

        }
    }
}
