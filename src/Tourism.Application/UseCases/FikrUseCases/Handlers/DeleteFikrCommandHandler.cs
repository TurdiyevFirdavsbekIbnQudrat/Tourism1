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

namespace Tourism.Application.UseCases.FikrUseCases.Handlers
{
    public class DeleteFikrCommandHandler:IRequestHandler<DeleteFikrCommand,string>
    {
        private readonly ITourismDbContext _tourism;

        public DeleteFikrCommandHandler(ITourismDbContext tourism)
        {
            _tourism = tourism;
        }
        public async Task<string> Handle(DeleteFikrCommand request, CancellationToken cancellationToken)
        {
            var fikr = await _tourism.fikrlar.FirstOrDefaultAsync(x => x.id == request.id);
            if (fikr != null)
            {
                try
                {
                    _tourism.fikrlar.Remove(fikr);
                    await _tourism.SaveChangesAsync(cancellationToken);
                    return "o'chirildi!!!";
                }
                catch
                {
                    return "o'chirilmadi!!!";
                }
            }
            return "ma'lumot topilmadi!!!";
        }

    }
}
