using MediatR;
using Microsoft.EntityFrameworkCore;
using Tourism.Application.Abstraction;
using Tourism.Application.UseCases.ShaharlarUseCases.Commands;

namespace Tourism.Application.UseCases.ShaharlarUseCases.Handlers
{
    public class DeleteShaharlarCommandHandler : IRequestHandler<DeleteShaharlarCommand, string>
    {
        private readonly ITourismDbContext _tourism;

        public DeleteShaharlarCommandHandler(ITourismDbContext tourism)
        {
            _tourism = tourism;
        }
        public async Task<string> Handle(DeleteShaharlarCommand request, CancellationToken cancellationToken)
        {
            var Shaharlar = await _tourism.shaharlar.FirstOrDefaultAsync(x => x.id == request.id);
            if (Shaharlar != null)
            {
                try
                {
                    _tourism.shaharlar.Remove(Shaharlar);
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
