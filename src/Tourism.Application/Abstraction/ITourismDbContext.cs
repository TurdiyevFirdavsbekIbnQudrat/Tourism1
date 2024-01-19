using Microsoft.EntityFrameworkCore;
using Toursim.Domain.Entities;

namespace Tourism.Application.Abstraction
{
    public interface ITourismDbContext
    {
        DbSet<Foydalanuvchi> foydalanuvchilar { get; set; }
        DbSet<Fikr> fikrlar { get; set; }
        DbSet<FoydalanuvchiVaShahar> foydalanuvchiVaShaharlar {  get; set; }
        DbSet<Shahar> shaharlar {  get; set; }
        DbSet<Tolov> tolovlar { get; set; }
        DbSet<Xizmatlar> xizmatlar { get; set; }
        DbSet<Admin> adminlar { get; set; }
        public ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
