using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using Tourism.Application.Abstraction;
using Tourism.Application.UseCases.ShaharlarUseCases.Queries;
using Toursim.Domain.Entities;

namespace Tourism.Application.UseCases.ShaharlarUseCases.Handlers
{
    public class GetByIdShaharlarCommandHandler : IRequestHandler<GetByIdShaharlarCommand, Shahar>
    {
        private readonly ITourismDbContext _tourism;
        private readonly IDistributedCache _distributedCache;

        public GetByIdShaharlarCommandHandler(ITourismDbContext tourism, IDistributedCache distributedcache)
        {
            _tourism = tourism;
            _distributedCache = distributedcache;
        }
        public async Task<Shahar> Handle(GetByIdShaharlarCommand request, CancellationToken cancellationToken)
        {
            var fromCache = await _distributedCache.GetStringAsync($"{request.id}");

            if (fromCache is null)
            {
                var values = _tourism.shaharlar.FirstOrDefault(user => user.id == request.id);

                fromCache = JsonSerializer.Serialize(values);
                await _distributedCache.SetStringAsync($"{values.id}", fromCache, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60)
                });

            }

            var result = JsonSerializer.Deserialize<Shahar>(fromCache);

            //Shahar result = await _tourism.shaharlar.FirstOrDefaultAsync(x => x.id == request.id);
            if (result != null)
            {
                return result;
            }
            return new Shahar();
        }
    }
}
