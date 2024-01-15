using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.UseCases.TolovUseCases.Commands;
using Tourism.Application.UseCases.TolovUseCases.Queries;
using Toursim.Domain.Entities;

namespace Tourism.Application.UseCases.TolovUseCases.Handlers
{
    public class GetByIdTolovCommandHandler:IRequestHandler<GetByIdTolovCommand,Tolov>
    {
    }
}
