using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Abstraction;
using Tourism.Application.UseCases.FikrUseCases.Commands;
using Tourism.Application.UseCases.FoydalanuvchiUseCases.Commands;
using Toursim.Domain.Enums;

namespace Tourism.Application.UseCases.FikrUseCases.Handlers
{
    public class UpdateFikrCommandHandler:IRequestHandler<UpdateFikrCommand,string>
    {
        private ITourismDbContext _tourism;

        public UpdateFikrCommandHandler(ITourismDbContext tourism)
        {
            _tourism = tourism;
        }

        public async Task<string> Handle(UpdateFikrCommand request, CancellationToken cancellationToken)
        {
            var fikr = await _tourism.fikrlar.FirstOrDefaultAsync(x => x.id == request.id);
            if (fikr != null)
            {
                fikr.foydalanuvchiFikr = request.foydalanuvchiFikr;
                fikr.foydalanunchiId = request.foydalanunchiId;
                try
                {
                    _tourism.fikrlar.Update(fikr);
                    await _tourism.SaveChangesAsync(cancellationToken);
                    return "yangilandi!!!";
                }
                catch
                {
                    return "yangilanmadi!!!";
                }
            }
            return "ma'lumot topilmadi!!!";

        }
    }
}
