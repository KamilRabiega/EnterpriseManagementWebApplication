using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Entities.ViewModels;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace EnterpriseManagementApp.Pages.Finance.Confirmations
{
    [Authorize(Policy = "financeadmin")]
    public class EditStockIssueConfirmationModel : PageModel
    {
        private readonly IProductionItemRepository productionItemRepository;

        public EditStockIssueConfirmationModel(IProductionItemRepository productionItemRepository)
        {
            this.productionItemRepository = productionItemRepository;
        }
        [BindProperty]
        public StockIssueConfirmation StockIssueConfirmation { get; set; }
        [BindProperty]
        public List<ProductionItem> ProductionItems { get; set; }
        public List<Entities.Type> Types { get; set; }
        public List<Company> Companies { get; set; }
        public List<Tax> Taxes { get; set; }
        public async Task OnGet(Guid id)
        {
            ProductionItems = (await productionItemRepository.GetAllAsync())?.ToList();
            Types = (await productionItemRepository.GetTypesAsync())?.ToList();
            Companies = (await productionItemRepository.GetCompaniesAsync())?.ToList();
            Taxes = (await productionItemRepository.GetTaxesAsync())?.ToList();
            StockIssueConfirmation = await productionItemRepository.GetCiAsync(id);
        }

        public async Task<IActionResult> OnPostUpdate()
        {
            try
            {
                await productionItemRepository.UpdateCiAsync(StockIssueConfirmation);

                var notification = new Notification
                {
                    Message = "Product with ID: " + StockIssueConfirmation.Id + " was successfully updated.",
                    Type = Enums.NotificationType.Success
                };

                TempData["Notification"] = JsonSerializer.Serialize(notification);

                return RedirectToPage("/Finance/Confirmations/ListStockIssueConfirmation");
            }
            catch (Exception)
            {
                ViewData["Notification"] = new Notification
                {
                    Message = "Something went wrong, please try again or contact with administrator of application.",
                    Type = Enums.NotificationType.Error
                };
            }
            return Page();
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var deleted = await productionItemRepository.DeleteAsync(StockIssueConfirmation.Id);

            if (deleted)
            {
                var notification = new Notification
                {
                    Message = "CI with ID: " + StockIssueConfirmation.Id + " was deleted successfully.",
                    Type = Enums.NotificationType.Success
                };

                TempData["Notification"] = JsonSerializer.Serialize(notification);

                return RedirectToPage("/Finance/Confirmations/ListStockIssueConfirmation");
            }
            return Page();
        }
    }
}
