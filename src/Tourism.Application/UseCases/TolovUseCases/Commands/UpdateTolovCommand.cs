using MediatR;

namespace Tourism.Application.UseCases.TolovUseCases.Commands
{
    public class UpdateTolovCommand : IRequest<string>
    {

        public int id { get; set; }
        public double tolovQiymati { get; set; }
        public int foydalanuvchiId { get; set; }
    }
}
