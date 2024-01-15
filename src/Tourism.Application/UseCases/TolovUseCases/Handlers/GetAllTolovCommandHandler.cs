using MediatR;
using Microsoft.EntityFrameworkCore;
using Tourism.Application.Abstraction;
using Tourism.Application.UseCases.FoydalanuvchiUseCases.Queries;
using Tourism.Application.UseCases.TolovUseCases.Queries;
using Toursim.Domain.Entities;

namespace Tourism.Application.UseCases.TolovUseCases.Handlers
{
    public class GetAllTolovCommandHandler:IRequestHandler<GetAllTolovCommand,IEnumerable<Tolov>>
    {
        private readonly ITourismDbContext _tourism;

        public GetAllTolovCommandHandler(ITourismDbContext tourism)
        {
            _tourism = tourism;
        }

        public async Task<IEnumerable<Tolov>> Handle(GetAllTolovCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<Tolov> result = await _tourism.tolovlar.ToListAsync();
            if (result != null)
            {
                return result;
            }

            return Enumerable.Empty<Tolov>();

        }
    }
}
