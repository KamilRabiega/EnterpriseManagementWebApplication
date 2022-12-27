using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Entities.ViewModels;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseManagementApp.Pages.Board.Finances
{
    [Authorize(Policy = "boardadmin")]
    public class SetIncomeDatesModel : PageModel
    {
        private readonly IProductionItemRepository productionItemRepository;
        private readonly ICostRepository costRepository;
        public SetIncomeDatesModel(IProductionItemRepository productionItemRepository, ICostRepository costRepository)
        {
            this.productionItemRepository = productionItemRepository;
            this.costRepository = costRepository;
        }
        [BindProperty]
        public DateTime IncomeMonth { get; set; }
        public List<Cost> Costs { get; set; }
        public List<StockIssueConfirmation> StockIssueConfirmations { get; set; }
        public IEnumerable<Cost> CostsPeriodQuery { get; set; }
        public IEnumerable<StockIssueConfirmation> CiPeriodQuery { get; set; }
        public void OnGet()
        {

        }
        public async Task OnPost()
        {
            Costs = (await costRepository.GetAllAsync())?.ToList();
            StockIssueConfirmations = (await productionItemRepository.GetCIsAsync())?.ToList();

            var incomeMonth = IncomeMonth;

            if (Costs != null && StockIssueConfirmations != null)
            {
                CostsPeriodQuery = (from item in Costs
                                  where item.PaymentDate.Month == incomeMonth.Month && item.PaymentDate.Year == incomeMonth.Year
                                  select item).ToList();

                CiPeriodQuery = (from item in StockIssueConfirmations
                                  where item.CIDate.Month == incomeMonth.Month && item.CIDate.Year == incomeMonth.Year
                                  select item).ToList();

                if (CostsPeriodQuery != null && CostsPeriodQuery.Any() && CiPeriodQuery != null && CiPeriodQuery.Any())
                {
                    var notification = new Notification
                    {
                        Message = "Success.",
                        Type = Enums.NotificationType.Success
                    };

                    ViewData["Notification"] = notification;
                }
                else if(CostsPeriodQuery != null && CiPeriodQuery != null)
                {
                    var notification = new Notification
                    {
                        Message = "There are no costs or revenues in that month.",
                        Type = Enums.NotificationType.Info
                    };

                    ViewData["Notification"] = notification;
                }
                else
                {
                    var notification = new Notification
                    {
                        Message = "Error, contact with support.",
                        Type = Enums.NotificationType.Error
                    };

                    ViewData["Notification"] = notification;
                }
            }
        }
    }
}
