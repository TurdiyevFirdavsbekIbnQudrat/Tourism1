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
    public class GetByIdXizmatlarCommandHandler:IRequestHandler<GetByIdXizmatlarCommand,Xizmatlar>
    {
        private readonly ITourismDbContext _tourism;

        public GetByIdXizmatlarCommandHandler(ITourismDbContext tourism)
        {
            _tourism = tourism;
        }
        public async Task<Xizmatlar> Handle(GetByIdXizmatlarCommand request, CancellationToken cancellationToken)
        {
            Xizmatlar result = await _tourism.xizmatlar.FirstOrDefaultAsync(x => x.id == request.id);
            if (result != null)
            {
                return result;
            }
            return new Xizmatlar();
        }
    }
}
