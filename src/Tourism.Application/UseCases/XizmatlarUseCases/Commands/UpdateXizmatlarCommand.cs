using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.Application.UseCases.XizmatlarUseCases.Commands
{
    public class UpdateXizmatlarCommand:IRequest<string>
    {
        public int id { get; set; }
        public string nomi { get; set; }
        public int narxi { get; set; }
        public string rasm { get; set; }
        public string boshlanishVaqti { get; set; }
        public string tugashVaqti { get; set; }
        public string haqida { get; set; }
        public string kun { get; set; }
        public int shaharId { get; set; }
    }
}
