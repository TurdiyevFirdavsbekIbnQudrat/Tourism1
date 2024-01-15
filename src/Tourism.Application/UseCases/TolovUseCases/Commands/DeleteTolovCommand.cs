using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.Application.UseCases.TolovUseCases.Commands
{
    public class DeleteTolovCommand:IRequest<string>
    {
        public int id { get; set; }
    }
}
