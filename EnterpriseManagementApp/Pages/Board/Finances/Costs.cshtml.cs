using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Entities.ViewModels;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace EnterpriseManagementApp.Pages.Board.Finances
{
    [Authorize(Policy = "boardadmin")]
    public class CostsModel : PageModel
    {
        private readonly ICostRepository costRepository;

        public CostsModel(ICostRepository costRepository)
        {
            this.costRepository = costRepository;
        }
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
