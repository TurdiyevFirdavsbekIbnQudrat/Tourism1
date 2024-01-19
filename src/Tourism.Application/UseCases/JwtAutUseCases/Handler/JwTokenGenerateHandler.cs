using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tourism.Application.UseCases.JwtAutUseCases.Command;

namespace Tourism.Application.UseCases.JwtAutUseCases.Handler
{
    public class JwTokenGenerateHandler : IRequestHandler<JwtCommand, string>
    {
        private readonly IConfiguration _configuration;

        public JwTokenGenerateHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<string> Handle(JwtCommand request, CancellationToken cancellationToken)
        {
            string username = request.username;
            string role = request.role;
        // token generatsiya qilamiz
        
            // bu malumotlar
            var claims = new Claim[]
            {
                // name 
                new Claim(JwtRegisteredClaimNames.Name, username),
                // identificatori
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                // vaqti
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                // role qo'shilmoqda
                new Claim(ClaimTypes.Role, role)

            };

            // qandedur algoritm boyicha shifrlanadi
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
                SecurityAlgorithms.HmacSha256
                );

            var token = new JwtSecurityToken(
                _configuration["JWT:ValidIssuer"],
                _configuration["JWT:ValidAudience"],
                claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials
                );

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
    
}
