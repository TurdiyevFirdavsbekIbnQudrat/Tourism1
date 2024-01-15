using MediatR;
using Toursim.Domain.Entities;

namespace Tourism.Application.UseCases.FikrUseCases.Queries
{
    public class GetAllFikrCommand : IRequest<IEnumerable<Fikr>>
    {

    }
}
