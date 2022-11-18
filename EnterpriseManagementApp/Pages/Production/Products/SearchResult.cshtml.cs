using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Entities.ViewModels;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

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
            var notification = (string)TempData["Notification"];
            if (notification != null)
            {
                ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(notification);
            }
            ProductionItem = await productionItemRepository.GetAsync(id);
        }
    }
}
