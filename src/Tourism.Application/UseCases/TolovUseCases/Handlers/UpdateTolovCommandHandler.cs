using MediatR;
using Microsoft.EntityFrameworkCore;
using Tourism.Application.Abstraction;
using Tourism.Application.UseCases.TolovUseCases.Commands;

namespace Tourism.Application.UseCases.TolovUseCases.Handlers
{
    public class UpdateTolovCommandHandler : IRequestHandler<UpdateTolovCommand, string>
    {
        private ITourismDbContext _tourism;

        public UpdateTolovCommandHandler(ITourismDbContext tourism)
        {
            _tourism = tourism;
        }

        public async Task<string> Handle(UpdateTolovCommand request, CancellationToken cancellationToken)
        {
            var tolov = await _tourism.tolovlar.FirstOrDefaultAsync(x => x.id == request.id);
            if (tolov != null)
            {
                tolov.tolovQiymati = request.tolovQiymati;
                tolov.foydalanuvchiId = request.foydalanuvchiId;
                try
                {
                    _tourism.tolovlar.Update(tolov);
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
