using MediatR;
using Toursim.Domain.Entities;

namespace Tourism.Application.UseCases.TolovUseCases.Queries
{
    public class GetAllTolovCommand : IRequest<IEnumerable<Tolov>>
    {
    }
}
