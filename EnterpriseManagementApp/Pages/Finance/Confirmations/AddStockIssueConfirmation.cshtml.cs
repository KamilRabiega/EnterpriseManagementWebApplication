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
    public class AddStockIssueConfirmationModel : PageModel
    {
        private readonly IProductionItemRepository productionItemRepository;

        public AddStockIssueConfirmationModel(IProductionItemRepository productionItemRepository)
        {
            this.productionItemRepository = productionItemRepository;
        }
        [BindProperty]
        public AddNewCI AddNewCI { get; set; }
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

        public async Task<IActionResult> OnPost()
        {
            var newEma = "OurName Company";
            var newStockIssueConfirmation = new StockIssueConfirmation()
            {
                CIName = AddNewCI.CIName,
                CINumber = AddNewCI.CINumber,
                CompanyId = AddNewCI.CompanyId,
                Net = AddNewCI.Net,
                Gross = AddNewCI.Gross,
                TaxClassId = AddNewCI.TaxClassId,
                ProductionItemId = AddNewCI.ProductionItemId,
                CIDate = AddNewCI.CIDate,
                DateOfPayment = AddNewCI.DateOfPayment,
                EmaCompany = newEma,
            };
            var selectedId = AddNewCI.ProductionItemId;

            await productionItemRepository.AddCIAsync(newStockIssueConfirmation);
            await productionItemRepository.ReadyToReleaseAsync(selectedId);

            var notification = new Notification
            {
                Message = "This Stock Issue Confirmation was created succesfully.",
                Type = Enums.NotificationType.Success
            };

            TempData["Notification"] = JsonSerializer.Serialize(notification);

            return RedirectToPage("/Finance/Confirmations/ListStockIssueConfirmation");
        }
    }
}
