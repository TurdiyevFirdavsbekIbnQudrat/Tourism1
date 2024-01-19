using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.Application.UseCases.JwtAutUseCases.Command
{
    public class JwtCheckCommand:IRequest<string>
    {
        public string email { get; set; }
        public string parol { get; set; }
    }
}
