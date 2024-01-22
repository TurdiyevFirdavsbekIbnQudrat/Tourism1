using MediatR;
using Toursim.Domain.Entities;

namespace Tourism.Application.UseCases.FoydalanuvchiUseCases.Commands
{
    public class UpdateByEmailNameCommand:IRequest<Foydalanuvchi>
    {
        public string email {  get; set; }
        public string ism { get; set; }
        public string parol { get; set; }
        public string telNomer { get; set; }
    }
}
