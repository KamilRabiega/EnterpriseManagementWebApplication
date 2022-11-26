using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Entities.ViewModels;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace EnterpriseManagementApp.Pages.Magazine.Products
{
    [Authorize(Policy = "magazineadmin")]
    public class PickUpModel : PageModel
    {
        private readonly IProductionItemRepository productionItemRepository;

        [BindProperty]
        public ProductionItem ProductionItem { get; set; }
        public PickUpModel(IProductionItemRepository productionItemRepository)
        {
            this.productionItemRepository = productionItemRepository;
        }
        public async Task<IActionResult> OnGet(Guid id)
        {
            DateTime dateTimeNow = DateTime.Now;
            ProductionItem = await productionItemRepository.GetAsync(id);
            ProductionItem.ReceivedByMagazine = true;
            ProductionItem.ReadyToRelease = false;
            ProductionItem.MagPickupDate = dateTimeNow;
            await productionItemRepository.UpdateAsync(ProductionItem);

            var notification = new Notification
            {
                Message = "Product with ID: " + ProductionItem.Id + " has been received from production department.",
                Type = Enums.NotificationType.Success
            };

            TempData["Notification"] = JsonSerializer.Serialize(notification);

            return RedirectToPage("/Magazine/Products/ProductionList");
        }
    }
}
