using EnterpriseManagementApp.Entities.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseManagementApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public Login LoginViewModel { get; set; }

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var loginResult = await signInManager.PasswordSignInAsync(LoginViewModel.Username, LoginViewModel.Password, false, false);

            if(loginResult.Succeeded)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                ViewData["Notification"] = new Notification
                {
                    Type = Enums.NotificationType.Error,
                    Message = "Login failed, try again"
                };
                return Page();
            }
        }
    }
}
