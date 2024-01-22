using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Abstraction;
using Tourism.Application.UseCases.FoydalanuvchiUseCases.Commands;
using Toursim.Domain.Entities;

namespace Tourism.Application.UseCases.FoydalanuvchiUseCases.Handlers
{
    public class UpdateByEmailNameCommandHandler : IRequestHandler<UpdateByEmailNameCommand, Foydalanuvchi>
    {
        private readonly ITourismDbContext _turizm;

        public UpdateByEmailNameCommandHandler(ITourismDbContext turizm)
        {
            _turizm = turizm;
        }

        public async Task<Foydalanuvchi> Handle(UpdateByEmailNameCommand request, CancellationToken cancellationToken)
        {
            var foydalanuvchi = await _turizm.foydalanuvchilar
                .FirstOrDefaultAsync(x => x.email.Equals(request.email) 
                                         && x.ism.Equals(request.ism)
                                         && x.telNomer.Equals(request.telNomer));
            if (foydalanuvchi != null)
            {
                foydalanuvchi.parol=request.parol;
                foydalanuvchi.condition = Toursim.Domain.Enums.Condition.updated;
                _turizm.foydalanuvchilar.Update(foydalanuvchi);
                await _turizm.SaveChangesAsync();
                return foydalanuvchi;
            }
            return new Foydalanuvchi();
        }
    }
}
