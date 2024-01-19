using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toursim.Domain.Entities;

namespace Tourism.Infrastructure.Configuration
{
    public class AdminTypeConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasData(

               new Admin() {
                   Id = 1,
                   email = "admin@gmail.com",
                   familiya = "Turdiyev",
                   ism = "Firdavsbek",
                   parol = "12345678"
               }
               );
        }
    }
}
