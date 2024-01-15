using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Abstraction;
using Tourism.Application.UseCases.ShaharlarUseCases.Commands;
using Tourism.Application.UseCases.XizmatlarUseCases.Commands;

namespace Tourism.Application.UseCases.XizmatlarUseCases.Handlers
{
    public class DeleteXizmatlarCommandHandler:IRequestHandler<DeleteXizmatlarCommand,string>
    {
        private readonly ITourismDbContext _tourism;

        public DeleteXizmatlarCommandHandler(ITourismDbContext tourism)
        {
            _tourism = tourism;
        }
        public async Task<string> Handle(DeleteXizmatlarCommand request, CancellationToken cancellationToken)
        {
            var xizmatlar = await _tourism.xizmatlar.FirstOrDefaultAsync(x => x.id == request.id);
            if (xizmatlar != null)
            {
                try
                {
                    _tourism.xizmatlar.Remove(xizmatlar);
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
