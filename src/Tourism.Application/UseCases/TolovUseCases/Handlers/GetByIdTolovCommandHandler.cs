using MediatR;
using Microsoft.EntityFrameworkCore;
using Tourism.Application.Abstraction;
using Tourism.Application.UseCases.FoydalanuvchiUseCases.Queries;
using Tourism.Application.UseCases.TolovUseCases.Queries;
using Toursim.Domain.Entities;

namespace Tourism.Application.UseCases.TolovUseCases.Handlers
{
    public class GetByIdTolovCommandHandler : IRequestHandler<GetByIdTolovCommand, Tolov>
    {
        private readonly ITourismDbContext _tourism;

        public GetByIdTolovCommandHandler(ITourismDbContext tourism)
        {
            _tourism = tourism;
        }
        public async Task<Tolov> Handle(GetByIdTolovCommand request, CancellationToken cancellationToken)
        {
            Tolov result = await _tourism.tolovlar.FirstOrDefaultAsync(x => x.id == request.id);
            if (result != null)
            {
                return result;
            }
            return new Tolov();
        }
    }
}
