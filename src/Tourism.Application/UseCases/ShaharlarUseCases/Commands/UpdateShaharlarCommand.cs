using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.Application.UseCases.ShaharlarUseCases.Commands
{
    public class UpdateShaharlarCommand:IRequest<string>
    {
        public int id { get; set; }
        public string nomi { get; set; }
        public string rasm { get; set; }
    }

}
