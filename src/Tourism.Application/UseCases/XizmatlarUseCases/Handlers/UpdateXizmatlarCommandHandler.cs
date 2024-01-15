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
using Toursim.Domain.Entities;

namespace Tourism.Application.UseCases.XizmatlarUseCases.Handlers
{
    public class UpdateXizmatlarCommandHandler:IRequestHandler<UpdateXizmatlarCommand,string>
    {
        private ITourismDbContext _tourism;

        public UpdateXizmatlarCommandHandler(ITourismDbContext tourism)
        {
            _tourism = tourism;
        }

        public async Task<string> Handle(UpdateXizmatlarCommand request, CancellationToken cancellationToken)
        {
            var xizmat = await _tourism.xizmatlar.FirstOrDefaultAsync(x => x.id == request.id);
            if (xizmat != null)
            {
                xizmat.nomi = request.nomi;
                xizmat.rasm = request.rasm;
                xizmat.shaharId = request.shaharId;
                xizmat.boshlanishVaqti = request.boshlanishVaqti;
                xizmat.haqida = request.haqida;
                xizmat.kun = request.kun;
                xizmat.narxi = request.narxi;
                xizmat.tugashVaqti = request.tugashVaqti;
                try
                {
                    _tourism.xizmatlar.Update(xizmat);
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
