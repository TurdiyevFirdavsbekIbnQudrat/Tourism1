using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toursim.Domain.Entities;

namespace Tourism.Application.UseCases.XizmatlarUseCases.Queries
{
    public class GetAllXizmatlarCommand:IRequest<IEnumerable<Xizmatlar>>
    {
    }
}
