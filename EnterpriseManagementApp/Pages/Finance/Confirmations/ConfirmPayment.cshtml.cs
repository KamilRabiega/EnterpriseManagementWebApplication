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
    public class ConfirmPaymentModel : PageModel
    {
        private readonly IProductionItemRepository productionItemRepository;

        public ConfirmPaymentModel(IProductionItemRepository productionItemRepository)
        {
            this.productionItemRepository = productionItemRepository;
        }
        [BindProperty]
        public ProductionItem ProductionItem { get; set; }
        [BindProperty]
        public StockIssueConfirmation StockIssueConfirmation { get; set; }
        public async Task<IActionResult> OnGet(Guid id)
        {
            StockIssueConfirmation = await productionItemRepository.GetCiAsync(id);
            StockIssueConfirmation.IsPaid = true;
            await productionItemRepository.UpdateCiAsync(StockIssueConfirmation);

            var notification = new Notification
            {
                Message = "The status of the Stock Issue Confirmation with ID: " + StockIssueConfirmation.Id + " has been changed to paid.",
                Type = Enums.NotificationType.Success
            };

            TempData["Notification"] = JsonSerializer.Serialize(notification);

            return RedirectToPage("/Finance/Confirmations/ListOfReleasedCIs");
        }
    }
}
