using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseManagementApp.Pages.Magazine.Products
{
    [Authorize(Policy = "magazineadmin")]
    public class ReleaseProductModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
