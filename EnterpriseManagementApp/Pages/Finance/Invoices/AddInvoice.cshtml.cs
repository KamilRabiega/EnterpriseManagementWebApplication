using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Entities.ViewModels;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace EnterpriseManagementApp.Pages.Finance.Invoices
{
    [Authorize(Policy = "financeadmin")]
    public class AddInvoiceModel : PageModel
    {
        private readonly IProductionItemRepository productionItemRepository;

        public AddInvoiceModel(IProductionItemRepository productionItemRepository)
        {
            this.productionItemRepository = productionItemRepository;
        }
        [BindProperty]
        public AddNewInvoice AddNewInvoice { get; set; }
        public List<ProductionItem> ProductionItems { get; set; }
        public List<Entities.Type> Types { get; set; }
        public List<Material> Materials { get; set; }
        public List<Hall> Halls { get; set; }
        public List<Foreman> Foremen { get; set; }
        public List<Invoice> Invoices { get; set; }
        public List<Company> Companies { get; set; }
        public List<Tax> Taxes { get; set; }
        public async Task OnGet()
        {
            var notification = (string)TempData["Notification"];
            if (notification != null)
            {
                ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(notification);
            }

            ProductionItems = (await productionItemRepository.GetAllAsync())?.ToList();
            Invoices = (await productionItemRepository.GetInvoicesAsync())?.ToList();
            Types = (await productionItemRepository.GetTypesAsync())?.ToList();
            Materials = (await productionItemRepository.GetMaterialsAsync())?.ToList();
            Halls = (await productionItemRepository.GetHallsAsync())?.ToList();
            Foremen = (await productionItemRepository.GetForemenAsync())?.ToList();
            Taxes = (await productionItemRepository.GetTaxesAsync())?.ToList();
            Companies = (await productionItemRepository.GetCompaniesAsync())?.ToList();


        }

        public async Task<IActionResult> OnPost()
        {
            var newEma = "OurName Company";
            var newInvoice = new Invoice()
            {
                InvoiceName = AddNewInvoice.InvoiceName,
                InvoiceNumber = AddNewInvoice.InvoiceNumber,
                CompanyId = AddNewInvoice.CompanyId,
                Net = AddNewInvoice.Net,
                Gross = AddNewInvoice.Gross,
                TaxClassId = AddNewInvoice.TaxClassId,
                ProductionItemId = AddNewInvoice.ProductionItemId,
                InvoiceDate = AddNewInvoice.InvoiceDate,
                DateOfPayment = AddNewInvoice.DateOfPayment,
                EmaCompany = newEma,
            };
            var selectedId = AddNewInvoice.ProductionItemId;
            
            await productionItemRepository.AddInvoiceAsync(newInvoice);
            await productionItemRepository.ReadyToReleaseAsync(selectedId);

            var notification = new Notification
            {
                Message = "This invoice was created succesfully.",
                Type = Enums.NotificationType.Success
            };

            TempData["Notification"] = JsonSerializer.Serialize(notification);

            return RedirectToPage("/Finance/Invoices/InvoicesList");
        }
    }
}
