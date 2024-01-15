using MediatR;

namespace Tourism.Application.UseCases.TolovUseCases.Commands
{
    public class DeleteTolovCommand : IRequest<string>
    {
        public int id { get; set; }
    }
}
