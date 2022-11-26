namespace EnterpriseManagementApp.Entities
{
    public class Tax
    {
        public int Id { get; set; }
        public string TaxClassName { get; set; }
        public int TaxClassValue { get; set; }
        public List<Invoice> Invoice { get; set; } = new List<Invoice>();

    }
}
