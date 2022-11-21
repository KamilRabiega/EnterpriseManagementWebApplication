using EnterpriseManagementApp.Data;
using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Entities.ViewModels;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace EnterpriseManagementApp.Pages.Production.Products
{
    [Authorize(Policy = "productionadmin")]
    public class AddModel : PageModel
    {
        private readonly IProductionItemRepository productionItemRepository;

        [BindProperty]
        public AddProductionItem AddProductionItemRequest { get; set; }

        public List<Entities.Type> Types { get; set; }
        public List<Material> Materials { get; set; }
        public List<Hall> Halls { get; set; }
        public List<Foreman> Foremen { get; set; }

        public AddModel(IProductionItemRepository productionItemRepository)
        {
            this.productionItemRepository = productionItemRepository;
        }

        public async Task OnGet()
        {
            Types = (await productionItemRepository.GetTypesAsync())?.ToList();
            Materials = (await productionItemRepository.GetMaterialsAsync())?.ToList();
            Halls = (await productionItemRepository.GetHallsAsync())?.ToList();
            Foremen = (await productionItemRepository.GetForemenAsync())?.ToList();
        }

        public async Task<IActionResult> OnPost()
        {
            DateTime dateTimeNow = DateTime.Now;

            var productionItem = new ProductionItem()
            {
                TypeId = AddProductionItemRequest.TypeId,
                MaterialId = AddProductionItemRequest.MaterialId,
                QuantityPCS = AddProductionItemRequest.QuantityPCS,
                QuantityPallets = AddProductionItemRequest.QuantityPallets,
                HallId = AddProductionItemRequest.HallId,
                ForemanId = AddProductionItemRequest.ForemanId,
                ProductionDate = dateTimeNow,
                AdditionalInformation = AddProductionItemRequest.AdditionalInformation,
                ReadyToPickUp = AddProductionItemRequest.ReadyToPickUp,
            };
            
            await productionItemRepository.AddAsync(productionItem);

            var notification = new Notification
            {
                Message = "This product was successfully added to database.",
                Type = Enums.NotificationType.Success
            };

            TempData["Notification"] = JsonSerializer.Serialize(notification);

            return RedirectToPage("/Production/Products/List");
        }
    }
}
