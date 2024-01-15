using Toursim.Domain.Enums;

namespace Tourism.API.Dtos.FoydalanuvchiDto
{
    public class UpdateFoydalanuvchiDto
    {
        public string ism { get; set; }
        public string familiya { get; set; }
        public string email { get; set; }
        public string parol { get; set; }
        public Role role { get; set; }
        public string telNomer { get; set; }
        public Condition condition { get; set; }
    }
}
