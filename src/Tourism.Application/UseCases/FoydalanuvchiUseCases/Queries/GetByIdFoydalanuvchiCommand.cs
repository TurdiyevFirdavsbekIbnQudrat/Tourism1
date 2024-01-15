using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toursim.Domain.Entities;

namespace Tourism.Application.UseCases.FoydalanuvchiUseCases.Queries
{
    public class GetByIdFoydalanuvchiCommand:IRequest<Foydalanuvchi>
    {
        public int id { get; set; }
    }
}
