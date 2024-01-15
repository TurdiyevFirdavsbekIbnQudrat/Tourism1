using MediatR;
using Microsoft.EntityFrameworkCore;
using Tourism.Application.Abstraction;
using Tourism.Application.UseCases.FoydalanuvchiUseCases.Queries;
using Toursim.Domain.Entities;

namespace Tourism.Application.UseCases.FoydalanuvchiUseCases.Handlers
{
    public class GetAllFoydalanuvchiCommandHandler : IRequestHandler<GetAllFoydalanuvchiCommand, IEnumerable<Foydalanuvchi>>
    {
        private readonly ITourismDbContext _tourism;

        public GetAllFoydalanuvchiCommandHandler(ITourismDbContext tourism)
        {
            _tourism = tourism;
        }

        public async Task<IEnumerable<Foydalanuvchi>> Handle(GetAllFoydalanuvchiCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<Foydalanuvchi> result =await _tourism.foydalanuvchilar.ToListAsync();
            if (result != null) {
                return result;
            }
            
            return Enumerable.Empty<Foydalanuvchi>();
            
        }
    }
}
