using System.ComponentModel.DataAnnotations;

namespace EnterpriseManagementApp.Entities
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public String NameOfCompany { get; set; }
        public String Director { get; set; }
        public List<StockIssueConfirmation> StockIssueConfirmation { get; set; } = new List<StockIssueConfirmation>();
    }
}
