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

        public void OnGet(Guid id)
        {
            ProductionItem = emaDbContext.ProductionItems.Find(id); //Passing the id from razorpage
        }

        public IActionResult OnPostUpdate()
        {
            var existingProductionItem = emaDbContext.ProductionItems.Find(ProductionItem.Id);

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

            emaDbContext.SaveChanges();
            return RedirectToPage("/Production/Products/List");
        }

        public IActionResult OnPostDelete()
        {
            var existingProductionItem = emaDbContext.ProductionItems.Find(ProductionItem.Id);

            if (existingProductionItem != null)
            {
                emaDbContext.ProductionItems.Remove(existingProductionItem);
                emaDbContext.SaveChanges();

                return RedirectToPage("/Production/Products/List");
            }
            return RedirectToPage();
        }
    }
}
