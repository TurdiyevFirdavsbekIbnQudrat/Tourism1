using MediatR;
using Microsoft.EntityFrameworkCore;
using Tourism.Application.Abstraction;
using Tourism.Application.UseCases.FoydalanuvchiUseCases.Queries;
using Toursim.Domain.Entities;

namespace Tourism.Application.UseCases.FoydalanuvchiUseCases.Handlers
{
    public class GetByIdFoydalanuvchiCommandHandler : IRequestHandler<GetByIdFoydalanuvchiCommand, Foydalanuvchi>
    {
        private readonly ITourismDbContext _tourism;

        public GetByIdFoydalanuvchiCommandHandler(ITourismDbContext tourism)
        {
            _tourism = tourism;
        }
        public async Task<Foydalanuvchi> Handle(GetByIdFoydalanuvchiCommand request, CancellationToken cancellationToken)
        {
            Foydalanuvchi result = await _tourism.foydalanuvchilar.FirstOrDefaultAsync(x => x.id == request.id);
            if (result != null)
            {
                return result;
            }
            return new Foydalanuvchi();
        }
    }
}
