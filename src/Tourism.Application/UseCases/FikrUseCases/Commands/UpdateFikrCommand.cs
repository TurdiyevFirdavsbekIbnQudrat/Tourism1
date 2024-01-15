using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.Application.UseCases.FikrUseCases.Commands
{
    public class UpdateFikrCommand:IRequest<string>
    {
        public int id { get; set; }
        public string foydalanuvchiFikr { get; set; }
        public int foydalanunchiId { get; set; }
    }
}
