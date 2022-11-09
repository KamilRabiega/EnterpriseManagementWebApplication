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
        public DbSet<Entities.Type> Type { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Material> Materials { get; set; }
    }
}
