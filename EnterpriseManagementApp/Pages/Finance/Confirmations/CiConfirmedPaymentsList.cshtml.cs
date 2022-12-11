using EnterpriseManagementApp.Entities.ViewModels;
using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace EnterpriseManagementApp.Pages.Finance.Confirmations
{
    [Authorize(Policy = "financeadmin")]
    public class CiConfirmedPaymentsListModel : PageModel
    {
        private readonly IProductionItemRepository productionItemRepository;

        public CiConfirmedPaymentsListModel(IProductionItemRepository productionItemRepository)
        {
            this.productionItemRepository = productionItemRepository;
        }
        public List<ProductionItem> ProductionItems { get; set; }
        public List<StockIssueConfirmation> StockIssueConfirmations { get; set; }
        public List<Company> Companies { get; set; }

        public async Task OnGet()
        {
            var notification = (string)TempData["Notification"];
            if (notification != null)
            {
                ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(notification);
            }

            ProductionItems = (await productionItemRepository.GetAllAsync())?.ToList();
            StockIssueConfirmations = (await productionItemRepository.GetCIsAsync())?.ToList();
            Companies = (await productionItemRepository.GetCompaniesAsync())?.ToList();
        }
    }
}
