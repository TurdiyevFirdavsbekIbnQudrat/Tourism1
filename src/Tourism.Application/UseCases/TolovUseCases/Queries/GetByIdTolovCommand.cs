using MediatR;
using Toursim.Domain.Entities;

namespace Tourism.Application.UseCases.TolovUseCases.Queries
{
    public class GetByIdTolovCommand : IRequest<Tolov>
    {
        public int id { get; set; }
    }
}
