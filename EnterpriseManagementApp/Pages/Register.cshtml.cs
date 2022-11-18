using EnterpriseManagementApp.Entities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseManagementApp.Pages
{
    [Authorize(Roles = "Admin")]
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> userMaganer;

        [BindProperty]
        public Register RegisterViewModel { get; set; }

        public RegisterModel(UserManager<IdentityUser> userMaganer)
        {
            this.userMaganer = userMaganer;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var user = new IdentityUser
            {
                UserName = RegisterViewModel.Username,
                Email = RegisterViewModel.Email
            };

            var identityResult = await userMaganer.CreateAsync(user, RegisterViewModel.Password);

            if (identityResult.Succeeded)
            {
                var selectedRole = await userMaganer.AddToRoleAsync(user, RegisterViewModel.Role);

                if (selectedRole.Succeeded)
                {
                    ViewData["Notification"] = new Notification
                    {
                        Type = Enums.NotificationType.Success,
                        Message = "User was created successfully."
                    };
                    return Page();
                }
            }
            ViewData["Notification"] = new Notification
            {
                Type = Enums.NotificationType.Error,
                Message = "User wasn't created successfully, try again or contact to our support."
            };
            return Page();
        }
    }
}
