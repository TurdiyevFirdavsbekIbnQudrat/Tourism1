using MediatR;

namespace Tourism.Application.UseCases.JwtAutUseCases.Command
{
    public class JwtCommand : IRequest<string>
    {
        public string email { get; set; }
        public string role { get; set; }
    }
}
