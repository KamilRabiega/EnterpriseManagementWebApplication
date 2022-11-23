namespace EnterpriseManagementApp.Entities
{
    public class Hall
    {
        public int Id { get; set; }
        public String Value { get; set; }
        public String ShortValue { get; set; }
        public List<ProductionItem> ProductionItem { get; set; } = new List<ProductionItem>();
    }
}
