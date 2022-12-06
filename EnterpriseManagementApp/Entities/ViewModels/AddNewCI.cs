namespace EnterpriseManagementApp.Entities.ViewModels
{
    public class AddNewCI
    {
        public String CIName { get; set; }
        public String CINumber { get; set; }
        public int CompanyId { get; set; }
        public String EmaCompany { get; set; }
        public int Net { get; set; }
        public int Gross { get; set; }
        public int TaxClassId { get; set; }
        public Guid ProductionItemId { get; set; }
        public DateTime DateOfPayment { get; set; }
        public DateTime CIDate { get; set; }
    }
}
