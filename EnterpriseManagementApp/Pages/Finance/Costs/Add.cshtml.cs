using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Entities.ViewModels;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace EnterpriseManagementApp.Pages.Finance.Costs
{
    [Authorize(Policy = "financeadmin")]
    public class AddModel : PageModel
    {
        private readonly ICostRepository costRepository;

        public AddModel(ICostRepository costRepository)
        {
            this.costRepository = costRepository;
        }
        [BindProperty]
        public AddCost AddCostRequest { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var cost = new Cost()
            {
                Name = AddCostRequest.Name,
                CostValue= AddCostRequest.CostValue,
                PaymentDate = AddCostRequest.PaymentDate
            };

            await costRepository.AddAsync(cost);

            var notification = new Notification
            {
                Message = "Costs added successfully.",
                Type = Enums.NotificationType.Success
            };

            TempData["Notification"] = JsonSerializer.Serialize(notification);

            return RedirectToPage("/Finance/Costs/ListCosts");
        }
    }
}
