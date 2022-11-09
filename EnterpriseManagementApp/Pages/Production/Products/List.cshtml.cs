using EnterpriseManagementApp.Data;
using EnterpriseManagementApp.Entities;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseManagementApp.Pages.Production.Products
{
    public class ListModel : PageModel
    {
        private readonly IProductionItemRepository productionItemRepository;

        public List<ProductionItem> ProductionItems { get; set; }

        public ListModel(IProductionItemRepository productionItemRepository)
        {
            this.productionItemRepository = productionItemRepository;
        }
        public async Task OnGet()
        {
            ProductionItems = (await productionItemRepository.GetAllAsync())?.ToList();
        }
    }
}
