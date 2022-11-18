using EnterpriseManagementApp.Data;
using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Entities.ViewModels;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace EnterpriseManagementApp.Pages.Production.Products
{
    public class AddModel : PageModel
    {
        private readonly IProductionItemRepository productionItemRepository;

        [BindProperty]
        public AddProductionItem AddProductionItemRequest { get; set; }

        public AddModel(IProductionItemRepository productionItemRepository)
        {
            this.productionItemRepository = productionItemRepository;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            DateTime dateTimeNow = DateTime.Now;

            var productionItem = new ProductionItem()
            {
                Type = AddProductionItemRequest.Type,
                Material = AddProductionItemRequest.Material,
                Thickness = AddProductionItemRequest.Thickness,
                Length = AddProductionItemRequest.Length,
                Diameter = AddProductionItemRequest.Diameter,
                QuantityPCS = AddProductionItemRequest.QuantityPCS,
                QuantityPallets = AddProductionItemRequest.QuantityPallets,
                HallNumber = AddProductionItemRequest.HallNumber,
                Foreman = AddProductionItemRequest.Foreman,
                ProductionDate = dateTimeNow, //AddProductionItemRequest.ProductionDate,
                AdditionalInformation = AddProductionItemRequest.AdditionalInformation,
                ReadyToPickUp = AddProductionItemRequest.ReadyToPickUp,
            };
            
            await productionItemRepository.AddAsync(productionItem);

            var notification = new Notification
            {
                Message = "This product was successfully added to database.",
                Type = Enums.NotificationType.Success
            };

            TempData["Notification"] = JsonSerializer.Serialize(notification);

            return RedirectToPage("/Production/Products/List");
        }
    }
}
