using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Toursim.Domain.Entities;

namespace Tourism.Infrastructure.Configuration
{
    public class AdminTypeConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasData(

               new Admin()
               {
                   id = 1,
                   email = "admin@gmail.com",
                   familiya = "Turdiyev",
                   ism = "Firdavsbek",
                   parol = "12345678"
               }
               );
        }
    }
}
