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
        public DbSet<StockIssueConfirmation> StockIssueConfirmations { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Cost> Costs { get; set; }

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

            modelBuilder.Entity<StockIssueConfirmation>(eb =>
            {
                eb.HasOne(ci => ci.Tax)
                .WithMany(t => t.StockIssueConfirmation)
                .HasForeignKey(ci => ci.TaxClassId);

                eb.HasOne(ci => ci.ProductionItem)
                .WithMany(p => p.StockIssueConfirmation)
                .HasForeignKey(ci => ci.ProductionItemId);

                eb.HasOne(ci => ci.Company)
                .WithMany(c => c.StockIssueConfirmation)
                .HasForeignKey(ci => ci.CompanyId);
            });
        }
    }
}
