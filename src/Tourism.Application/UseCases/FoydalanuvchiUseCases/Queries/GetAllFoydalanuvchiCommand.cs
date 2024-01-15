using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toursim.Domain.Entities;
using Toursim.Domain.Enums;

namespace Tourism.Application.UseCases.FoydalanuvchiUseCases.Queries
{
    public class GetAllFoydalanuvchiCommand:IRequest<IEnumerable<Foydalanuvchi>>
    {
    }
}
