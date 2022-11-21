using EnterpriseManagementApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseManagementApp.Data
{
    public class EmaDbContext : DbContext
    {
        public EmaDbContext(DbContextOptions<EmaDbContext> options) : base(options)
        {
        }

        public DbSet<ProductionItem> ProductionItems { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Entities.Type> Types { get; set; }
        public DbSet<Foreman> Foremen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductionItem>(eb =>
            {
                //One to many relation beetween Type and ProductionItem tables
                eb.HasOne(p => p.Type)
                .WithMany(t => t.ProductionItem)
                .HasForeignKey(p => p.TypeId);

                //One to many relation beetween Material and ProductionItem tables
                eb.HasOne(p => p.Material)
                .WithMany(m => m.ProductionItem)
                .HasForeignKey(p => p.MaterialId);

                //One to many relation beetween Hall and ProductionItem tables
                eb.HasOne(p => p.Type)
                .WithMany(h => h.ProductionItem)
                .HasForeignKey(p => p.TypeId);

                //One to many relation beetween Foreman and ProductionItem tables
                eb.HasOne(p => p.Type)
                .WithMany(f => f.ProductionItem)
                .HasForeignKey(p => p.TypeId);
            });
        }
    }
}
