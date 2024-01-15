using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toursim.Domain.Enums;

namespace Tourism.Application.UseCases.FoydalanuvchiUseCases.Commands
{
    public class UpdateFoydalanuvchiCommand:IRequest<string>
    {
        public int id { get; set; }

        public string ism { get; set; }
        public string familiya { get; set; }
        public string email { get; set; }
        public string parol { get; set; }
        public Role role { get; set; }
        public string telNomer { get; set; }
        public Condition condition { get; set; }
    }
}
