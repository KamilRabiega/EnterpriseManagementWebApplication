using System.ComponentModel.DataAnnotations;

namespace EnterpriseManagementApp.Entities
{
    public class Foreman
    {
        [Key]
        public int Id { get; set; }
        public String UserName { get; set; }
        public string UserSHA { get; set; }
        public List<ProductionItem> ProductionItem { get; set; } = new List<ProductionItem>();
    }
}
