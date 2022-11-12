using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseManagementApp.Pages.Production.Products
{
    public class SearchEditModel : PageModel
    {
        private readonly IProductionItemRepository productionItemRepository;
        [BindProperty]
        public ProductionItem ProductionItem { get; set; }

        public SearchEditModel(IProductionItemRepository productionItemRepository)
        {
            this.productionItemRepository = productionItemRepository;
        }

        public async Task OnGet(Guid id)
        {
            ProductionItem = await productionItemRepository.GetAsync(id); //Passing the id from razorpage
        }
        public async Task<IActionResult> OnPostUpdate()
        {
            await productionItemRepository.UpdateAsync(ProductionItem);
            return RedirectToPage("/Production/Products/List");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var deleted = await productionItemRepository.DeleteAsync(ProductionItem.Id);

            if (deleted)
            {
                return RedirectToPage("/Production/Products/List");
            }
            return Page();
        }

    }
}
