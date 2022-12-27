using EnterpriseManagementApp.Entities;

namespace EnterpriseManagementApp.Repositories
{
    public interface ICostRepository
    {
        Task<Cost> AddAsync(Cost cost);
        Task<IEnumerable<Cost>> GetAllAsync();
        Task<Cost> GetAsync(int id);
        Task<Cost> UpdateAsync(Cost cost);
        Task<bool> DeleteAsync(int id);
    }
}
