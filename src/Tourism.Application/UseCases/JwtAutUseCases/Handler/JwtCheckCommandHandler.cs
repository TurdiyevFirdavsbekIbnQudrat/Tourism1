using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Abstraction;
using Tourism.Application.UseCases.JwtAutUseCases.Command;

namespace Tourism.Application.UseCases.JwtAutUseCases.Handler
{
    public class JwtCheckCommandHandler : IRequestHandler<JwtCheckCommand, string>
    {
        private readonly ITourismDbContext _tourism;

        public JwtCheckCommandHandler(ITourismDbContext tourism)
        {
            _tourism = tourism;
        }

        public async Task<string> Handle(JwtCheckCommand request, CancellationToken cancellationToken)
        {
            string role = await getRole(request.email, request.parol);
            if (role.Equals("mavjud emas!!!"))
            {
                return "mavjud emas!!!";
            }
            return role;
        }
        private async ValueTask<string> getRole(string email, string parol)
        {
            var x = await _tourism.adminlar.FirstOrDefaultAsync(x => x.email == email && x.parol == parol);
            if (x != null) return "admin";
            var y = await _tourism.foydalanuvchilar.FirstOrDefaultAsync(x => x.email == email && x.parol == parol);
            if (y != null) return "foydalanuvchi";
            return "mavjud emas!!!";

        }
    }

}
