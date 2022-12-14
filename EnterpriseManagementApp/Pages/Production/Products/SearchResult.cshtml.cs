using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Entities.ViewModels;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Text.Json;

namespace EnterpriseManagementApp.Pages.Production.Products
{
    [Authorize(Policy = "productionadmin")]
    public class SearchResultModel : PageModel
    {
        private readonly IProductionItemRepository productionItemRepository;
        
        [BindProperty]
        public ProductionItem ProductionItem { get; set; }
        public List<Entities.Type> Types { get; set; }
        public List<Material> Materials { get; set; }
        public List<Hall> Halls { get; set; }
        public List<Foreman> Foremen { get; set; }
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
            Types = (await productionItemRepository.GetTypesAsync())?.ToList();
            Materials = (await productionItemRepository.GetMaterialsAsync())?.ToList();
            Halls = (await productionItemRepository.GetHallsAsync())?.ToList();
            Foremen = (await productionItemRepository.GetForemenAsync())?.ToList();
            ProductionItem = await productionItemRepository.GetAsync(id);
        }
    }
}
