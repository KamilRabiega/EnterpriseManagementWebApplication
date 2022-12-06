using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseManagementApp.Pages.Finance.Confirmations
{
    public class ViewStockIssueConfirmationModel : PageModel
    {
        private readonly IProductionItemRepository productionItemRepository;

        public ViewStockIssueConfirmationModel(IProductionItemRepository productionItemRepository)
        {
            this.productionItemRepository = productionItemRepository;
        }
        [BindProperty]
        public StockIssueConfirmation StockIssueConfirmation { get; set; }
        [BindProperty]
        public List<ProductionItem> ProductionItems { get; set; }
        public List<Entities.Type> Types { get; set; }
        public List<Company> Companies { get; set; }
        public List<Tax> Taxes { get; set; }    
        public async Task OnGet(Guid id)
        {
            var idOfCi = id;
            ProductionItems = (await productionItemRepository.GetAllAsync())?.ToList();
            Types = (await productionItemRepository.GetTypesAsync())?.ToList();
            Companies = (await productionItemRepository.GetCompaniesAsync())?.ToList();
            Taxes = (await productionItemRepository.GetTaxesAsync())?.ToList();
            StockIssueConfirmation = await productionItemRepository.GetCiAsync(id);
        }
    }
}
