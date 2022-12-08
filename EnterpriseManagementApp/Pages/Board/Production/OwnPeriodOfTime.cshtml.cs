using EnterpriseManagementApp.Data;
using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Entities.ViewModels;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace EnterpriseManagementApp.Pages.Board.Production
{
    [Authorize(Policy = "boardadmin")]
    public class OwnPeriodOfTimeModel : PageModel
    {
        private readonly IProductionItemRepository productionItemRepository;

        public OwnPeriodOfTimeModel(IProductionItemRepository productionItemRepository)
        {
            this.productionItemRepository = productionItemRepository;
        }
        [BindProperty]
        public DateTime StartDate { get; set; }
        [BindProperty]
        public DateTime EndDate { get; set; }
        public List<ProductionItem> ProductionItem { get; set; }
        public List<Entities.Type> Types { get; set; }
        public IEnumerable<ProductionItem> OwnPeriodQuery { get; set; }
        public void OnGet()
        {

        }

        public async Task OnPost()
        {
            Types = (await productionItemRepository.GetTypesAsync())?.ToList();
            ProductionItem = (await productionItemRepository.GetAllAsync())?.ToList();
            var startDate = StartDate;
            var endDate = EndDate;
            if (ProductionItem != null)
            {
                OwnPeriodQuery = (from item in ProductionItem
                         where item.ProductionDate >= startDate && item.ProductionDate <= endDate
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
