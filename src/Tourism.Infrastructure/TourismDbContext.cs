using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Tourism.Application.Abstraction;
using Tourism.Infrastructure.Configuration;
using Toursim.Domain.Entities;

namespace Tourism.Infrastructure
{
    public class TourismDbContext : DbContext,ITourismDbContext
    {
        public TourismDbContext(DbContextOptions<TourismDbContext> options) : base(options)
        {
            var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            if (databaseCreator != null)
            {
                if (!databaseCreator.CanConnect()) databaseCreator.CreateAsync();
                if (!databaseCreator.HasTables()) databaseCreator.CreateTablesAsync();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FoydalanuvchiTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AdminTypeConfiguration());
        }
        async ValueTask<int> ITourismDbContext.SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
        public  DbSet<Foydalanuvchi> foydalanuvchilar { get; set; }
        public DbSet<Fikr> fikrlar { get; set; }
        public DbSet<FoydalanuvchiVaShahar> foydalanuvchiVaShaharlar { get; set; }
        public DbSet<Shahar> shaharlar { get; set; }
        public DbSet<Tolov> tolovlar { get; set; }
        public DbSet<Xizmatlar> xizmatlar { get; set; }
        public DbSet<Admin> adminlar { get; set; }
    }
    
}
