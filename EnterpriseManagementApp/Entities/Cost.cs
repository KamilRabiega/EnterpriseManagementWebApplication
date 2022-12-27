namespace EnterpriseManagementApp.Entities
{
    public class Cost
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public decimal CostValue { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
