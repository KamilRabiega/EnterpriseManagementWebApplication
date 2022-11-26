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

        public async Task<Invoice> AddInvoiceAsync(Invoice invoice)
        {
            await emaDbContext.Invoices.AddAsync(invoice);
            await emaDbContext.SaveChangesAsync();
            return invoice;
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

        public async Task<ProductionItem> ReadyToReleaseAsync(Guid id)
        {
            var existingProductionItem = await emaDbContext.ProductionItems.FindAsync(id);

            if (existingProductionItem != null)
            {
                existingProductionItem.ReadyToRelease = true;
            }

            await emaDbContext.SaveChangesAsync();
            return existingProductionItem;
        }

        public async Task<IEnumerable<ProductionItem>> GetAllAsync()
        {
            return await emaDbContext.ProductionItems.ToListAsync();
        }

        public async Task<ProductionItem> GetAsync(Guid id)
        {
            return await emaDbContext.ProductionItems.FindAsync(id);
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            return await emaDbContext.Companies.ToListAsync();
        }

        public async Task<IEnumerable<Foreman>> GetForemenAsync()
        {
            return await emaDbContext.Foremen.ToListAsync();
        }

        public async Task<IEnumerable<Hall>> GetHallsAsync()
        {
            return await emaDbContext.Halls.ToListAsync();
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesAsync()
        {
            return await emaDbContext.Invoices.ToListAsync();
        }

        public async Task<IEnumerable<Material>> GetMaterialsAsync()
        {
            return await emaDbContext.Materials.ToListAsync();
        }

        public async Task<IEnumerable<Tax>> GetTaxesAsync()
        {
            return await emaDbContext.Taxes.ToListAsync();
        }

        public async Task<IEnumerable<Entities.Type>> GetTypesAsync()
        {
            return await emaDbContext.Types.ToListAsync();
        }

        public async Task<ProductionItem> UpdateAsync(ProductionItem productionItem)
        {
            var existingProductionItem = await emaDbContext.ProductionItems.FindAsync(productionItem.Id);

            if (existingProductionItem != null)
            {
                existingProductionItem.TypeId= productionItem.TypeId;
                existingProductionItem.MaterialId= productionItem.MaterialId;
                existingProductionItem.HallId= productionItem.HallId;
                existingProductionItem.ForemanId= productionItem.ForemanId;
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
