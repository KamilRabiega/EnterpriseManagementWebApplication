using EnterpriseManagementApp.Data;
using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Entities.ViewModels;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace EnterpriseManagementApp.Pages.Production.Products
{
    public class ListModel : PageModel
    {
        private readonly IProductionItemRepository productionItemRepository;

        public List<ProductionItem> ProductionItems { get; set; }

        public ListModel(IProductionItemRepository productionItemRepository)
        {
            this.productionItemRepository = productionItemRepository;
        }
        public async Task OnGet()
        {
            var notification = (string)TempData["Notification"];
            if(notification != null)
            {
                ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(notification);
            }

            ProductionItems = (await productionItemRepository.GetAllAsync())?.ToList();
        }
    }
}
