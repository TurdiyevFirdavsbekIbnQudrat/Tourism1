using MediatR;
using Toursim.Domain.Entities;

namespace Tourism.Application.UseCases.FikrUseCases.Commands
{
    public class CreateFikrCommand : IRequest<Fikr>
    {
        public string foydalanuvchiFikr { get; set; }
        public int foydalanunchiId { get; set; }
    }
}
