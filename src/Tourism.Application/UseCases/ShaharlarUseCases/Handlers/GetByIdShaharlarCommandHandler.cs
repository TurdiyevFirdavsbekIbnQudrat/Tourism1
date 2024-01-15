using MediatR;
using Microsoft.EntityFrameworkCore;
using Tourism.Application.Abstraction;
using Tourism.Application.UseCases.ShaharlarUseCases.Queries;
using Toursim.Domain.Entities;

namespace Tourism.Application.UseCases.ShaharlarUseCases.Handlers
{
    public class GetByIdShaharlarCommandHandler : IRequestHandler<GetByIdShaharlarCommand, Shahar>
    {
        private readonly ITourismDbContext _tourism;

        public GetByIdShaharlarCommandHandler(ITourismDbContext tourism)
        {
            _tourism = tourism;
        }
        public async Task<Shahar> Handle(GetByIdShaharlarCommand request, CancellationToken cancellationToken)
        {
            Shahar result = await _tourism.shaharlar.FirstOrDefaultAsync(x => x.id == request.id);
            if (result != null)
            {
                return result;
            }
            return new Shahar();
        }
    }
}
