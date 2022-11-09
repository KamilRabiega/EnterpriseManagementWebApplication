using EnterpriseManagementApp.Data;
using EnterpriseManagementApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseManagementApp.Pages.Production.Products
{
    public class EditModel : PageModel
    {
        private readonly EmaDbContext emaDbContext;
        [BindProperty]
        public ProductionItem ProductionItem { get; set; }

        public EditModel(EmaDbContext emaDbContext)
        {
            this.emaDbContext = emaDbContext;
        }

        public async Task OnGet(Guid id)
        {
            ProductionItem = await emaDbContext.ProductionItems.FindAsync(id); //Passing the id from razorpage
        }

        public async Task<IActionResult> OnPostUpdate()
        {
            var existingProductionItem = await emaDbContext.ProductionItems.FindAsync(ProductionItem.Id);

            if (existingProductionItem != null)
            {
                existingProductionItem.Type= ProductionItem.Type;
                existingProductionItem.Material= ProductionItem.Material;
                existingProductionItem.Thickness = ProductionItem.Thickness;
                existingProductionItem.Length= ProductionItem.Length;
                existingProductionItem.Diameter= ProductionItem.Diameter;
                existingProductionItem.QuantityPCS= ProductionItem.QuantityPCS;
                existingProductionItem.QuantityPallets= ProductionItem.QuantityPallets;
                existingProductionItem.AdditionalInformation= ProductionItem.AdditionalInformation;
                existingProductionItem.ReadyToPickUp= ProductionItem.ReadyToPickUp;
            }

            await emaDbContext.SaveChangesAsync();
            return RedirectToPage("/Production/Products/List");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var existingProductionItem = await emaDbContext.ProductionItems.FindAsync(ProductionItem.Id);

            if (existingProductionItem != null)
            {
                emaDbContext.ProductionItems.Remove(existingProductionItem);
                await emaDbContext.SaveChangesAsync();

                return RedirectToPage("/Production/Products/List");
            }
            return RedirectToPage();
        }
    }
}
