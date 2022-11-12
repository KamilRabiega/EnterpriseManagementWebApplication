using EnterpriseManagementApp.Data;
using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Entities.ViewModels;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseManagementApp.Pages.Production.Products
{
    public class SearchModel : PageModel
    {
        [BindProperty]
        public string? SearchText { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrEmpty(SearchText))
            {
                return Redirect("/Production/Products/SearchResult/" + SearchText);
            }
            else
            {
                return Redirect("/Index");
            }
        }

    }
}
