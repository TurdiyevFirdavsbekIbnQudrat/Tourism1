using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.Application.UseCases.FikrUseCases.Commands
{
    public class DeleteFikrCommand:IRequest<string>
    {
        public int id { get; set; }
    }
}
