using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Entities.ViewModels;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace EnterpriseManagementApp.Pages.Production.Products
{
    [Authorize(Policy = "productionadmin")]
    public class ListUnpickedUpModel : PageModel
    {
        private readonly IProductionItemRepository productionItemRepository;

        public ListUnpickedUpModel(IProductionItemRepository productionItemRepository)
        {
            this.productionItemRepository = productionItemRepository;
        }
        [BindProperty]
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

            var notification = (string)TempData["Notification"];
            if (notification != null)
            {
                ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(notification);
            }

            ProductionItems = (await productionItemRepository.GetAllAsync())?.ToList();
        }
    }
}
