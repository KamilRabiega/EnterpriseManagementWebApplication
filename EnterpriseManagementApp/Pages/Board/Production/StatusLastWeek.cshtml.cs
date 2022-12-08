using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseManagementApp.Pages.Board.Production
{
    [Authorize(Policy = "boardadmin")]
    public class StatusLastWeekModel : PageModel
    {
        private readonly IProductionItemRepository productionItemRepository;

        public StatusLastWeekModel(IProductionItemRepository productionItemRepository)
        {
            this.productionItemRepository = productionItemRepository;
        }
        [BindProperty]
        public List<ProductionItem> ProductionItems { get; set; }
        [BindProperty]
        public List<Entities.Type> Types { get; set; }
        public async Task OnGet()
        {
            Types = (await productionItemRepository.GetTypesAsync())?.ToList();
            ProductionItems = (await productionItemRepository.GetAllAsync())?.ToList();
        }
    }
}
