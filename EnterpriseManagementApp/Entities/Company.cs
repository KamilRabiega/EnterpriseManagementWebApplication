using System.ComponentModel.DataAnnotations;

namespace EnterpriseManagementApp.Entities
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public String NameOfCompany { get; set; }
        public String Director { get; set; }
        public List<Invoice> Invoice { get; set; } = new List<Invoice>();
    }
}
