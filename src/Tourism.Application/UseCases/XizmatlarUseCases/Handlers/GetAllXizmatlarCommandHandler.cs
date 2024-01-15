using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Abstraction;
using Tourism.Application.UseCases.ShaharlarUseCases.Queries;
using Tourism.Application.UseCases.XizmatlarUseCases.Queries;
using Toursim.Domain.Entities;

namespace Tourism.Application.UseCases.XizmatlarUseCases.Handlers
{
    public class GetAllXizmatlarCommandHandler:IRequestHandler<GetAllXizmatlarCommand,IEnumerable<Xizmatlar>>
    {
        private readonly ITourismDbContext _tourism;

        public GetAllXizmatlarCommandHandler(ITourismDbContext tourism)
        {
            _tourism = tourism;
        }

        public async Task<IEnumerable<Xizmatlar>> Handle(GetAllXizmatlarCommand request, CancellationToken cancellationToken)
        {

            IEnumerable<Xizmatlar> result = await _tourism.xizmatlar.ToListAsync();
            if (result != null)
            {
                return result;
            }

            return Enumerable.Empty<Xizmatlar>();

        }
    }
}
