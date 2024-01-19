using MediatR;

namespace Tourism.Application.UseCases.JwtAutUseCases.Command
{
    public class JwtCommand : IRequest<string>
    {
        public string username { get; set; }
        public string role { get; set; }
    }
}
