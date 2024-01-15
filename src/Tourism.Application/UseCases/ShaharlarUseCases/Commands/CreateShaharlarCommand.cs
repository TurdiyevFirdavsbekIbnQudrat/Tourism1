using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toursim.Domain.Entities;

namespace Tourism.Application.UseCases.ShaharlarUseCases.Commands
{
    public class CreateShaharlarCommand:IRequest<Shahar>
    {
        public string nomi { get; set; }
        public string rasm { get; set; }
    }
}
