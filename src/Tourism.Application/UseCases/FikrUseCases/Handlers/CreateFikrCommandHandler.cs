using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Abstraction;
using Tourism.Application.UseCases.FikrUseCases.Commands;
using Tourism.Application.UseCases.FoydalanuvchiUseCases.Commands;
using Toursim.Domain.Entities;
using Toursim.Domain.Enums;

namespace Tourism.Application.UseCases.FikrUseCases.Handlers
{
    public class CreateFikrCommandHandler:IRequestHandler<CreateFikrCommand,Fikr>
    {
        private readonly ITourismDbContext _tourism;

        public CreateFikrCommandHandler(ITourismDbContext tourism)
        {
            _tourism = tourism;
        }

        public async Task<Fikr> Handle(CreateFikrCommand request, CancellationToken cancellationToken)
        {
            var command = new Fikr()
            {
                foydalanunchiId = request.foydalanunchiId,
                foydalanuvchiFikr = request.foydalanuvchiFikr
            };
            try
            {
                await _tourism.fikrlar.AddAsync(command);
                _tourism.SaveChangesAsync(cancellationToken);
                return command;
            }
            catch
            {
                return new Fikr();
            }

        }
    }
}
