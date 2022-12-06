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

        public async Task<StockIssueConfirmation> AddCIAsync(StockIssueConfirmation stockIssueConfirmation)
        {
            await emaDbContext.StockIssueConfirmations.AddAsync(stockIssueConfirmation);
            await emaDbContext.SaveChangesAsync();
            return stockIssueConfirmation;
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

        public async Task<IEnumerable<StockIssueConfirmation>> GetCIsAsync()
        {
            return await emaDbContext.StockIssueConfirmations.ToListAsync();
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

        public async Task<StockIssueConfirmation> GetCiAsync(Guid id)
        {
            return await emaDbContext.StockIssueConfirmations.FindAsync(id);
        }

        public async Task<StockIssueConfirmation> UpdateCiAsync(StockIssueConfirmation stockIssueConfirmation)
        {
            var existingCi = await emaDbContext.StockIssueConfirmations.FindAsync(stockIssueConfirmation.Id);

            if(existingCi != null)
            {
                existingCi.CIName = stockIssueConfirmation.CIName;
                existingCi.CINumber = stockIssueConfirmation.CINumber;
                existingCi.CompanyId = stockIssueConfirmation.CompanyId;
                existingCi.EmaCompany = stockIssueConfirmation.EmaCompany;
                existingCi.Net = stockIssueConfirmation.Net;
                existingCi.Gross = stockIssueConfirmation.Gross;
                existingCi.TaxClassId = stockIssueConfirmation.TaxClassId;
                existingCi.ProductionItemId = stockIssueConfirmation.ProductionItemId;
                existingCi.CIDate = stockIssueConfirmation.CIDate;
                existingCi.DateOfPayment = stockIssueConfirmation.DateOfPayment;
            }
            await emaDbContext.SaveChangesAsync();
            return existingCi;
        }

        public async Task<bool> DeleteCiAsync(Guid id)
        {
            var existingCi = await emaDbContext.StockIssueConfirmations.FindAsync(id);

            if (existingCi != null)
            {
                emaDbContext.StockIssueConfirmations.Remove(existingCi);
                await emaDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
