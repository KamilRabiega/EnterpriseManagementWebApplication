using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Entities.ViewModels;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseManagementApp.Pages.Board.Finances
{
    [Authorize(Policy = "boardadmin")]
    public class SetCostsDatesModel : PageModel
    {
        private readonly ICostRepository costRepository;

        public SetCostsDatesModel(ICostRepository costRepository)
        {
            this.costRepository = costRepository;
        }
        [BindProperty]
        public DateTime StartDate { get; set; }
        [BindProperty]
        public DateTime EndDate { get; set; }
        public List<Cost> Costs { get; set; }
        public IEnumerable<Cost> OwnPeriodQuery { get; set; }
        public void OnGet()
        {
        }
        public async Task OnPost()
        {
            Costs = (await costRepository.GetAllAsync())?.ToList();
            var startDate = StartDate;
            var endDate = EndDate;

            if (Costs != null)
            {
                OwnPeriodQuery = (from item in Costs
                                  where item.PaymentDate >= startDate && item.PaymentDate <= endDate
                                  select item).ToList();

                if (OwnPeriodQuery != null && OwnPeriodQuery.Any())
                {
                    var notification = new Notification
                    {
                        Message = "Success.",
                        Type = Enums.NotificationType.Success
                    };

                    ViewData["Notification"] = notification;
                }
                else
                {
                    var notification = new Notification
                    {
                        Message = "Error, please contact with support.",
                        Type = Enums.NotificationType.Error
                    };

                    ViewData["Notification"] = notification;
                }
            }
        }
    }
}
