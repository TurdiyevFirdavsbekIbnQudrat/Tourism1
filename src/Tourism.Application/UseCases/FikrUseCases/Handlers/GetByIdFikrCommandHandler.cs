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
    public class GetByIdFikrCommandHandler:IRequestHandler<GetByIdFikrCommand,Fikr>
    {
        private readonly ITourismDbContext _tourism;

        public GetByIdFikrCommandHandler(ITourismDbContext tourism)
        {
            _tourism = tourism;
        }
        public async Task<Fikr> Handle(GetByIdFikrCommand request, CancellationToken cancellationToken)
        {
            Fikr result = await _tourism.fikrlar.FirstOrDefaultAsync(x => x.id == request.id);
            if (result != null)
            {
                return result;
            }
            return new Fikr();
        }
    }
}
