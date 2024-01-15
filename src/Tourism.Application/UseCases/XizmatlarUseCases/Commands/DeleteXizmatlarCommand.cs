using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.Application.UseCases.XizmatlarUseCases.Commands
{
    public class DeleteXizmatlarCommand:IRequest<string>
    {
        public int id {  get; set; }
    }
}
