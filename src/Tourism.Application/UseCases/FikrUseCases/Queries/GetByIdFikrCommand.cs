using MediatR;
using Toursim.Domain.Entities;

namespace Tourism.Application.UseCases.FikrUseCases.Queries
{
    public class GetByIdFikrCommand : IRequest<Fikr>
    {
        public int id { get; set; }
    }
}
