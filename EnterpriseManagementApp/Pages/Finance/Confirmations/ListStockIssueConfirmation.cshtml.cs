using EnterpriseManagementApp.Entities.ViewModels;
using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace EnterpriseManagementApp.Pages.Finance.Confirmations
{
    [Authorize(Policy = "financeadmin")]
    public class ListStockIssueConfirmationModel : PageModel
    {
        private readonly IProductionItemRepository productionItemRepository;

        public ListStockIssueConfirmationModel(IProductionItemRepository productionItemRepository)
        {
            this.productionItemRepository = productionItemRepository;
        }
        public List<ProductionItem> ProductionItems { get; set; }
        public List<Entities.Type> Types { get; set; }
        public List<Material> Materials { get; set; }
        public List<Hall> Halls { get; set; }
        public List<Foreman> Foremen { get; set; }
        public List<StockIssueConfirmation> StockIssueConfirmations { get; set; }
        public List<Company> Companies { get; set; }
        public List<Tax> Taxes { get; set; }

        public async Task OnGet()
        {
            var notification = (string)TempData["Notification"];
            if (notification != null)
            {
                ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(notification);
            }

            ProductionItems = (await productionItemRepository.GetAllAsync())?.ToList();
            StockIssueConfirmations = (await productionItemRepository.GetCIsAsync())?.ToList();
            Types = (await productionItemRepository.GetTypesAsync())?.ToList();
            Materials = (await productionItemRepository.GetMaterialsAsync())?.ToList();
            Halls = (await productionItemRepository.GetHallsAsync())?.ToList();
            Foremen = (await productionItemRepository.GetForemenAsync())?.ToList();
            Taxes = (await productionItemRepository.GetTaxesAsync())?.ToList();
            Companies = (await productionItemRepository.GetCompaniesAsync())?.ToList();
        }
    }
}
