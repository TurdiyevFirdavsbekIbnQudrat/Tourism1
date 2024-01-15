using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Abstraction;
using Tourism.Application.UseCases.FikrUseCases.Queries;
using Tourism.Application.UseCases.FoydalanuvchiUseCases.Queries;
using Toursim.Domain.Entities;

namespace Tourism.Application.UseCases.FikrUseCases.Handlers
{
    public class GetAllFikrCommandHandler:IRequestHandler<GetAllFikrCommand,IEnumerable<Fikr>>
    {
        private readonly ITourismDbContext _tourism;

        public GetAllFikrCommandHandler(ITourismDbContext tourism)
        {
            _tourism = tourism;
        }

        public async Task<IEnumerable<Fikr>> Handle(GetAllFikrCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<Fikr> result = await _tourism.fikrlar.ToListAsync();
            if (result != null)
            {
                return result;
            }

            return Enumerable.Empty<Fikr>();

        }
    }
}
