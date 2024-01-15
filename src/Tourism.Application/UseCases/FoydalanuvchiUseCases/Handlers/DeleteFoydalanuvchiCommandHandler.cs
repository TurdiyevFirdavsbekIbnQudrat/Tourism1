using MediatR;
using Microsoft.EntityFrameworkCore;
using Tourism.Application.Abstraction;
using Tourism.Application.UseCases.FoydalanuvchiUseCases.Commands;

namespace Tourism.Application.UseCases.FoydalanuvchiUseCases.Handlers
{
    public class DeleteFoydalanuvchiCommandHandler : IRequestHandler<DeleteFoydalanuvchiCommand, string>
    {
        private readonly ITourismDbContext _tourism;

        public DeleteFoydalanuvchiCommandHandler(ITourismDbContext tourism)
        {
            _tourism = tourism;
        }
        public async Task<string> Handle(DeleteFoydalanuvchiCommand request, CancellationToken cancellationToken)
        {
            var turist = await _tourism.foydalanuvchilar.FirstOrDefaultAsync(x => x.id == request.id);
            if (turist != null)
            {
                try
                {
                    _tourism.foydalanuvchilar.Remove(turist);
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
