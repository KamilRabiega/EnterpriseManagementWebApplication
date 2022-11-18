using EnterpriseManagementApp.Data;
using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Entities.ViewModels;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseManagementApp.Pages.Production.Products
{
    [Authorize(Policy = "productionadmin")]
    public class SearchModel : PageModel
    {
        [BindProperty]
        public string? SearchText { get; set; }
        private bool TryParse(string? searchText, out Guid result)
        {
            throw new NotImplementedException();
        }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            var isValid = Guid.TryParse(SearchText, out Guid result);
            if(isValid == true)
            {
                return Redirect("/Production/Products/SearchResult/" + SearchText);
            }
            else
            {
                ViewData["Notification"] = new Notification
                {
                    Message = "You must use GUID type of ID.",
                    Type = Enums.NotificationType.Error
                };
                return Page();
            }
        }
       
    }
}
