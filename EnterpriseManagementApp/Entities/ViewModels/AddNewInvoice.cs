namespace EnterpriseManagementApp.Entities.ViewModels
{
    public class AddNewInvoice
    {
        public String InvoiceName { get; set; }
        public String InvoiceNumber { get; set; }
        public int CompanyId { get; set; }
        public String EmaCompany { get; set; }
        public int Net { get; set; }
        public int Gross { get; set; }
        public int TaxClassId { get; set; }
        public Guid ProductionItemId { get; set; }
        public DateTime DateOfPayment { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}
