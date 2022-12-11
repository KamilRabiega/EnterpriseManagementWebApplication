namespace EnterpriseManagementApp.Entities
{
    public class StockIssueConfirmation
    {
        public Guid Id { get; set; }
        public String CIName { get; set; }
        public String CINumber { get; set; }
        public Company Company { get; set; }
        public int? CompanyId { get; set; }
        public String EmaCompany { get; set; }
        public int Net { get; set; }
        public int Gross { get; set; }
        public Tax Tax { get; set; }
        public int? TaxClassId { get; set; }
        public ProductionItem ProductionItem { get; set; }
        public Guid? ProductionItemId { get; set; }
        public DateTime DateOfPayment { get; set; }
        public DateTime CIDate { get; set; }
        public bool? IsPaid { get; set; }
    }
}
