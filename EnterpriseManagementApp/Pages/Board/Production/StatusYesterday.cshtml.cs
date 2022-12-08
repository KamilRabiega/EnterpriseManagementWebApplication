using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseManagementApp.Pages.Board.Production
{
    [Authorize(Policy = "boardadmin")]
    public class StatusYesterdayModel : PageModel
    {
        private readonly IProductionItemRepository productionItemRepository;

        public StatusYesterdayModel(IProductionItemRepository productionItemRepository)
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
