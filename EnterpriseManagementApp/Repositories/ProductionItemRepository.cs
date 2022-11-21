using EnterpriseManagementApp.Data;
using EnterpriseManagementApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseManagementApp.Repositories
{
    public class ProductionItemRepository : IProductionItemRepository
    {
        private readonly EmaDbContext emaDbContext;

        public ProductionItemRepository(EmaDbContext emaDbContext)
        {
            this.emaDbContext = emaDbContext;
        }
        public async Task<ProductionItem> AddAsync(ProductionItem productionItem)
        {
            await emaDbContext.ProductionItems.AddAsync(productionItem);
            await emaDbContext.SaveChangesAsync();
            return productionItem;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existingProductionItem = await emaDbContext.ProductionItems.FindAsync(id);

            if (existingProductionItem != null)
            {
                emaDbContext.ProductionItems.Remove(existingProductionItem);
                await emaDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<ProductionItem>> GetAllAsync()
        {
            return await emaDbContext.ProductionItems.ToListAsync();
        }

        public async Task<ProductionItem> GetAsync(Guid id)
        {
            return await emaDbContext.ProductionItems.FindAsync(id);
        }

        public async Task<ProductionItem> UpdateAsync(ProductionItem productionItem)
        {
            var existingProductionItem = await emaDbContext.ProductionItems.FindAsync(productionItem.Id);

            if (existingProductionItem != null)
            {
                //existingProductionItem.Type = productionItem.Type;
                //existingProductionItem.Material = productionItem.Material;
                //existingProductionItem.Thickness = productionItem.Thickness;
                //existingProductionItem.Length = productionItem.Length;
                //existingProductionItem.Diameter = productionItem.Diameter;
                existingProductionItem.QuantityPCS = productionItem.QuantityPCS;
                existingProductionItem.QuantityPallets = productionItem.QuantityPallets;
                existingProductionItem.ProductionDate = productionItem.ProductionDate;
                existingProductionItem.AdditionalInformation = productionItem.AdditionalInformation;
                existingProductionItem.ReadyToPickUp = productionItem.ReadyToPickUp;
            }

            await emaDbContext.SaveChangesAsync();
            return existingProductionItem;
        }
    }
}
