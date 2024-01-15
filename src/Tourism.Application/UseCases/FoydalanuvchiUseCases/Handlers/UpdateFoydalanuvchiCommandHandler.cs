using MediatR;
using Microsoft.EntityFrameworkCore;
using Tourism.Application.Abstraction;
using Tourism.Application.UseCases.FoydalanuvchiUseCases.Commands;
using Toursim.Domain.Enums;

namespace Tourism.Application.UseCases.FoydalanuvchiUseCases.Handlers
{
    public class UpdateFoydalanuvchiCommandHandler : IRequestHandler<UpdateFoydalanuvchiCommand, string>
    {
        private ITourismDbContext _tourism;

        public UpdateFoydalanuvchiCommandHandler(ITourismDbContext tourism)
        {
            _tourism = tourism;
        }

        public async Task<string> Handle(UpdateFoydalanuvchiCommand request, CancellationToken cancellationToken)
        {
            var turist = await _tourism.foydalanuvchilar.FirstOrDefaultAsync(x => x.id == request.id);
            if (turist != null)
            {
                turist.ism = request.ism;
                turist.condition = Condition.created;
                turist.email = request.email;
                turist.familiya = request.familiya;
                turist.parol = request.parol;
                turist.role = Role.foydalanuvchi;
                turist.telNomer = request.telNomer;
                try
                {
                    _tourism.foydalanuvchilar.Update(turist);
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
