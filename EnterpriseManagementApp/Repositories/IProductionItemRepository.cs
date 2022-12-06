using EnterpriseManagementApp.Entities;

namespace EnterpriseManagementApp.Repositories
{
    public interface IProductionItemRepository
    {
        Task<IEnumerable<Entities.Type>> GetTypesAsync();
        Task<IEnumerable<Material>> GetMaterialsAsync();
        Task<IEnumerable<Hall>> GetHallsAsync();
        Task<IEnumerable<Foreman>> GetForemenAsync();
        Task<IEnumerable<StockIssueConfirmation>> GetCIsAsync();
        Task<IEnumerable<Tax>> GetTaxesAsync();
        Task<IEnumerable<Company>> GetCompaniesAsync();
        Task<IEnumerable<ProductionItem>> GetAllAsync();
        Task<StockIssueConfirmation> GetCiAsync(Guid id);
        Task<ProductionItem> GetAsync(Guid id);
        Task<ProductionItem> AddAsync(ProductionItem productionItem);
        Task<StockIssueConfirmation> AddCIAsync(StockIssueConfirmation stockIssueConfirmation);
        Task<StockIssueConfirmation> UpdateCiAsync(StockIssueConfirmation stockIssueConfirmation);
        Task<ProductionItem> UpdateAsync(ProductionItem productionItem);
        Task<ProductionItem> ReadyToReleaseAsync(Guid id);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> DeleteCiAsync(Guid id);
    }
}
