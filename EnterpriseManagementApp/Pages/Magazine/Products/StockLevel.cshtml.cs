using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseManagementApp.Pages.Magazine.Products
{
    [Authorize(Policy = "magazineadmin")]
    public class StockLevelModel : PageModel
    {
        private readonly IProductionItemRepository productionItemRepository;

        public StockLevelModel(IProductionItemRepository productionItemRepository)
        {
            this.productionItemRepository = productionItemRepository;
        }
        public List<ProductionItem> ProductionItems { get; set; }
        public List<Entities.Type> Types { get; set; }
        public List<Material> Materials { get; set; }
        public List<Hall> Halls { get; set; }
        public List<Foreman> Foremen { get; set; }
        public async Task OnGet()
        {
            Types = (await productionItemRepository.GetTypesAsync())?.ToList();
            Materials = (await productionItemRepository.GetMaterialsAsync())?.ToList();
            Halls = (await productionItemRepository.GetHallsAsync())?.ToList();
            Foremen = (await productionItemRepository.GetForemenAsync())?.ToList();
        }
    }
}
