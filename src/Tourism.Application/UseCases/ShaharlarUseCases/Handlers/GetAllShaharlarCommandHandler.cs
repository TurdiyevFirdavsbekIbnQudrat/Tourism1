using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Abstraction;
using Tourism.Application.UseCases.FoydalanuvchiUseCases.Queries;
using Tourism.Application.UseCases.ShaharlarUseCases.Queries;
using Toursim.Domain.Entities;

namespace Tourism.Application.UseCases.ShaharlarUseCases.Handlers
{
    public class GetAllShaharlarCommandHandler:IRequestHandler<GetAllShaharlarCommand,IEnumerable<Shahar>>
    {
        private readonly ITourismDbContext _tourism;

        public GetAllShaharlarCommandHandler(ITourismDbContext tourism)
        {
            _tourism = tourism;
        }

        public async Task<IEnumerable<Shahar>> Handle(GetAllShaharlarCommand request, CancellationToken cancellationToken)
        {

            IEnumerable<Shahar> result = await _tourism.shaharlar.ToListAsync();
            if (result != null)
            {
                return result;
            }

            return Enumerable.Empty<Shahar>();

        }
    }
}
