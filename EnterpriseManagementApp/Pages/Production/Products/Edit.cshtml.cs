using EnterpriseManagementApp.Data;
using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Entities.ViewModels;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace EnterpriseManagementApp.Pages.Production.Products
{
    [Authorize(Policy = "productionadmin")]
    public class EditModel : PageModel
    {
        private readonly IProductionItemRepository productionItemRepository;

        [BindProperty]
        public ProductionItem ProductionItem { get; set; }

        public EditModel(IProductionItemRepository productionItemRepository)
        {
            this.productionItemRepository = productionItemRepository;
        }

        public async Task OnGet(Guid id)
        {
            ProductionItem = await productionItemRepository.GetAsync(id); //Passing the id from razorpage
        }

        public async Task<IActionResult> OnPostUpdate()
        {
            try
            {
                await productionItemRepository.UpdateAsync(ProductionItem);

                var notification = new Notification
                {
                    Message = "Product with ID: " + ProductionItem.Id + " was successfully updated.",
                    Type = Enums.NotificationType.Success
                };

                TempData["Notification"] = JsonSerializer.Serialize(notification);

                return RedirectToPage("/Production/Products/List");
            }
            catch (Exception)
            {
                ViewData["Notification"] = new Notification
                {
                    Message = "Something went wrong, please try again or contact with administrator of application.",
                    Type = Enums.NotificationType.Error
                };
                //throw;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var deleted = await productionItemRepository.DeleteAsync(ProductionItem.Id);

            if(deleted) 
            {
                var notification = new Notification
                {
                    Message = "Product with ID: " + ProductionItem.Id + " was deleted successfully.",
                    Type = Enums.NotificationType.Success
                };

                TempData["Notification"] = JsonSerializer.Serialize(notification);

                return RedirectToPage("/Production/Products/List");
            }
            return Page();
        }
    }
}
