using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Abstraction;
using Tourism.Application.UseCases.FoydalanuvchiUseCases.Commands;
using Tourism.Application.UseCases.ShaharlarUseCases.Commands;
using Toursim.Domain.Entities;
using Toursim.Domain.Enums;

namespace Tourism.Application.UseCases.ShaharlarUseCases.Handlers
{
    public class UpdateShaharlarCommandHandler:IRequestHandler<UpdateShaharlarCommand,string>
    {
        private ITourismDbContext _tourism;

        public UpdateShaharlarCommandHandler(ITourismDbContext tourism)
        {
            _tourism = tourism;
        }

        public async Task<string> Handle(UpdateShaharlarCommand request, CancellationToken cancellationToken)
        {
            var shahar= await _tourism.shaharlar.FirstOrDefaultAsync(x => x.id == request.id);
            if (shahar != null)
            {
                shahar.nomi = request.nomi;
                shahar.rasm = request.rasm;
                try
                {
                    _tourism.shaharlar.Update(shahar);
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
