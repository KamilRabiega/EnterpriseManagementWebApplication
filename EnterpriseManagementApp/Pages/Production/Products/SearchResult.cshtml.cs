using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseManagementApp.Pages.Production.Products
{
    public class SearchResultModel : PageModel
    {
        private readonly IProductionItemRepository productionItemRepository;
        
        [BindProperty]
        public ProductionItem ProductionItem { get; set; }
        public SearchResultModel(IProductionItemRepository productionItemRepository)
        {
            this.productionItemRepository = productionItemRepository;
        }

        public async Task OnGet(Guid id)
        {
            ProductionItem = await productionItemRepository.GetAsync(id);
        }
    }
}
