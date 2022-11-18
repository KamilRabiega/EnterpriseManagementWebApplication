using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseManagementApp.Pages
{
    [Authorize(Roles = "Admin")]
    public class FuncionalityTestingModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
