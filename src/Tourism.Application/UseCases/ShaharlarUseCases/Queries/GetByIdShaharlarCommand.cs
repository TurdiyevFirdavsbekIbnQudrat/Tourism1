using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toursim.Domain.Entities;

namespace Tourism.Application.UseCases.ShaharlarUseCases.Queries
{
    public class GetByIdShaharlarCommand:IRequest<Shahar>
    {
        public int id {  get; set; }
    }
}
