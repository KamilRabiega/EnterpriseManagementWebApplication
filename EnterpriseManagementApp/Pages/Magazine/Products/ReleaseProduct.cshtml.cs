using EnterpriseManagementApp.Entities.ViewModels;
using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace EnterpriseManagementApp.Pages.Magazine.Products
{
    [Authorize(Policy = "magazineadmin")]
    public class ReleaseProductModel : PageModel
    {
        private readonly IProductionItemRepository productionItemRepository;

        public ReleaseProductModel(IProductionItemRepository productionItemRepository)
        {
            this.productionItemRepository = productionItemRepository;
        }
        [BindProperty]
        public ProductionItem ProductionItem { get; set; }
        public async Task<IActionResult> OnGet(Guid id)
        {
            ProductionItem = await productionItemRepository.GetAsync(id);
            ProductionItem.Released = true;
            ProductionItem.ReleaseDate = DateTime.Now;
            await productionItemRepository.UpdateAsync(ProductionItem);

            var notification = new Notification
            {
                Message = "Product with ID: " + ProductionItem.Id + " has been released to customer.",
                Type = Enums.NotificationType.Success
            };

            TempData["Notification"] = JsonSerializer.Serialize(notification);

            return RedirectToPage("/Magazine/Products/ReleaseList");
        }
    }
}
