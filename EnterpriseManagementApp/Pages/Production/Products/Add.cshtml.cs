using EnterpriseManagementApp.Data;
using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseManagementApp.Pages.Production.Products
{
    public class AddModel : PageModel
    {
        private readonly EmaDbContext emaDbContext;

        [BindProperty]
        public AddProductionItem AddProductionItemRequest { get; set; }

        public AddModel(EmaDbContext emaDbContext)
        {
            this.emaDbContext = emaDbContext;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
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
                ProductionDate = AddProductionItemRequest.ProductionDate,
                AdditionalInformation = AddProductionItemRequest.AdditionalInformation,
                ReadyToPickUp = AddProductionItemRequest.ReadyToPickUp,
            };
            await emaDbContext.ProductionItems.AddAsync(productionItem);
            await emaDbContext.SaveChangesAsync();

            return RedirectToPage("/Production/Products/List");
        }
    }
}
