using EnterpriseManagementApp.Data;
using EnterpriseManagementApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseManagementApp.Repositories
{
    public class CostRepository : ICostRepository
    {
        private readonly EmaDbContext emaDbContext;

        public CostRepository(EmaDbContext emaDbContext)
        {
            this.emaDbContext = emaDbContext;
        }

        public async Task<Cost> AddAsync(Cost cost)
        {
            await emaDbContext.Costs.AddAsync(cost);
            await emaDbContext.SaveChangesAsync();
            return cost;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingCost = await emaDbContext.Costs.FindAsync(id);

            if (existingCost != null)
            {
                emaDbContext.Costs.Remove(existingCost);
                await emaDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Cost>> GetAllAsync()
        {
            return await emaDbContext.Costs.ToListAsync();
        }

        public async Task<Cost> GetAsync(int id)
        {
            return await emaDbContext.Costs.FindAsync(id);
        }

        public async Task<Cost> UpdateAsync(Cost cost)
        {
            var existingCost = await emaDbContext.Costs.FindAsync(cost.Id);

            if (existingCost != null)
            {
                existingCost.Name = cost.Name;

                await emaDbContext.SaveChangesAsync();
            }
            return existingCost;
        }
    }
}
