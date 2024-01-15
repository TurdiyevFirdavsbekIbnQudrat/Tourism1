using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Abstraction;
using Tourism.Application.UseCases.FoydalanuvchiUseCases.Commands;
using Tourism.Application.UseCases.TolovUseCases.Commands;

namespace Tourism.Application.UseCases.TolovUseCases.Handlers
{
    public class DeleteTolovCommandHandler:IRequestHandler<DeleteTolovCommand,string>
    {
        private readonly ITourismDbContext _tourism;

        public DeleteTolovCommandHandler(ITourismDbContext tourism)
        {
            _tourism = tourism;
        }
        public async Task<string> Handle(DeleteTolovCommand request, CancellationToken cancellationToken)
        {
            var tolov = await _tourism.tolovlar.FirstOrDefaultAsync(x => x.id == request.id);
            if (tolov != null)
            {
                try
                {
                    _tourism.tolovlar.Remove(tolov);
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
