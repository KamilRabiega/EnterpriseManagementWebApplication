using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Entities.ViewModels;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseManagementApp.Pages.Board.Finances
{
    [Authorize(Policy = "boardadmin")]
    public class SetRevenuesDatesModel : PageModel
    {
        private readonly IProductionItemRepository productionItemRepository;

        public SetRevenuesDatesModel(IProductionItemRepository productionItemRepository)
        {
            this.productionItemRepository = productionItemRepository;
        }
        [BindProperty]
        public DateTime StartDate { get; set; }
        [BindProperty]
        public DateTime EndDate { get; set; }
        public List<StockIssueConfirmation> StockIssueConfirmation { get; set; }
        public IEnumerable<StockIssueConfirmation> OwnPeriodQuery { get; set; }
        public void OnGet()
        {
        }
        public async Task OnPost() 
        {
            StockIssueConfirmation = (await productionItemRepository.GetCIsAsync())?.ToList();
            var startDate = StartDate;
            var endDate = EndDate;

            if (StockIssueConfirmation != null)
            {
                OwnPeriodQuery = (from item in StockIssueConfirmation
                                  where item.CIDate >= startDate && item.CIDate <= endDate
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
