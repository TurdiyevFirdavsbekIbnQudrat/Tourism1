using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Toursim.Domain.Entities;
using Toursim.Domain.Enums;

namespace Tourism.Infrastructure.Configuration
{
    public class FoydalanuvchiTypeConfiguration : IEntityTypeConfiguration<Foydalanuvchi>
    {
        public void Configure(EntityTypeBuilder<Foydalanuvchi> builder)
        {
            builder.HasData(
                new Foydalanuvchi()
                {
                    id = 1,
                    ism="Firdavs",
                    condition=Condition.created,
                    email="Firdavs@gmail.com",
                    familiya="Turdiyev",
                    parol="12345678",
                    role=Role.foydalanuvchi,
                    telNomer="+998948663667",
                    foydalanuvchiVaShaharlar=null,
                  
                },
                new Foydalanuvchi()
                {
                    id = 2,
                    ism = "Quvvat",
                    condition = Condition.created,
                    email = "Quvvat@gmail.com",
                    familiya = "Turdiyev",
                    parol = "12345678",
                    role = Role.foydalanuvchi,
                    telNomer = "+998978683661",
                    foydalanuvchiVaShaharlar = null,
                    
                }
                );

        }
    }
}
