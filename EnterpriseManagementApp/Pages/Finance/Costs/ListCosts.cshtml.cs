using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Entities.ViewModels;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace EnterpriseManagementApp.Pages.Finance.Costs
{
    [Authorize(Policy = "financeadmin")]
    public class ListCostsModel : PageModel
    {
        private readonly ICostRepository costRepository;

        public ListCostsModel(ICostRepository costRepository)
        {
            this.costRepository = costRepository;
        }
        [BindProperty]
        public List<Cost> Costs { get; set; }
        public async Task OnGet()
        {
            var notification = (string)TempData["Notification"];
            if (notification != null)
            {
                ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(notification);
            }
            Costs = (await costRepository.GetAllAsync())?.ToList();
        }
    }
}
