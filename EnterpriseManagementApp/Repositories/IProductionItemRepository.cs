using EnterpriseManagementApp.Entities;

namespace EnterpriseManagementApp.Repositories
{
    public interface IProductionItemRepository
    {
        Task<IEnumerable<ProductionItem>> GetAllAsync(); //To get all production items
        Task<ProductionItem> GetAsync(Guid id); //To get a single one item by id
        Task<ProductionItem> AddAsync(ProductionItem productionItem); //To add a single item 
        Task<ProductionItem> UpdateAsync(ProductionItem productionItem); //To update single ProductionItem
        Task<bool> DeleteAsync(Guid id); // To delete
    }
}
