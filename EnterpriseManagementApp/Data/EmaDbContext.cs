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
        public DbSet<Company> Companies { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Tax> Taxes { get; set; }

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
                eb.HasOne(p => p.Hall)
                .WithMany(h => h.ProductionItem)
                .HasForeignKey(p => p.HallId);

                //One to many relation beetween Foreman and ProductionItem tables
                eb.HasOne(p => p.Foreman)
                .WithMany(f => f.ProductionItem)
                .HasForeignKey(p => p.ForemanId);
            });

            modelBuilder.Entity<Invoice>(eb =>
            {
                eb.HasOne(i => i.Tax)
                .WithMany(t => t.Invoice)
                .HasForeignKey(i => i.TaxClassId);

                eb.HasOne(i => i.ProductionItem)
                .WithMany(p => p.Invoice)
                .HasForeignKey(i => i.ProductionItemId);

                eb.HasOne(i => i.Company)
                .WithMany(c => c.Invoice)
                .HasForeignKey(i => i.CompanyId);
            });
        }
    }
}
