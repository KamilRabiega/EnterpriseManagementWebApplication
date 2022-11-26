using EnterpriseManagementApp.Entities;

namespace EnterpriseManagementApp.Repositories
{
    public interface IProductionItemRepository
    {
        Task<IEnumerable<Entities.Type>> GetTypesAsync(); //To get all types of products
        Task<IEnumerable<Material>> GetMaterialsAsync(); //To get all materials of products
        Task<IEnumerable<Hall>> GetHallsAsync(); //To get all halls of products
        Task<IEnumerable<Foreman>> GetForemenAsync(); //To get all foremen of products
        Task<IEnumerable<Invoice>> GetInvoicesAsync(); //To get all foremen of products
        Task<IEnumerable<Tax>> GetTaxesAsync(); //To get all foremen of products
        Task<IEnumerable<Company>> GetCompaniesAsync(); //To get all foremen of products
        Task<IEnumerable<ProductionItem>> GetAllAsync(); //To get all production items
        Task<ProductionItem> GetAsync(Guid id); //To get a single one item by id
        Task<ProductionItem> AddAsync(ProductionItem productionItem); //To add a single item 
        Task<Invoice> AddInvoiceAsync(Invoice invoice); //To add a single item 
        Task<ProductionItem> UpdateAsync(ProductionItem productionItem); //To update single ProductionItem
        Task<ProductionItem> ReadyToReleaseAsync(Guid id); //To update single ProductionItem
        Task<bool> DeleteAsync(Guid id); // To delete
    }
}
