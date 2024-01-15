using MediatR;
using Toursim.Domain.Entities;

namespace Tourism.Application.UseCases.TolovUseCases.Commands
{
    public class CreateTolovCommand : IRequest<Tolov>
    {
        public double tolovQiymati { get; set; }
        public int foydalanuvchiId { get; set; }
    }
}
