using EnterpriseManagementApp.Data;
using EnterpriseManagementApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseManagementApp.Pages.Production.Products
{
    public class ListModel : PageModel
    {
        private readonly EmaDbContext emaDbContext;
        public List<ProductionItem> ProductionItems { get; set; }

        public ListModel(EmaDbContext emaDbContext)
        {
            this.emaDbContext = emaDbContext;
        }
        public void OnGet()
        {
            ProductionItems = emaDbContext.ProductionItems.ToList();
        }
    }
}
