namespace EnterpriseManagementApp.Entities
{
    public class Material
    {
        public int Id { get; set; }
        public String Value { get; set; }
        public String? MoreInfo { get; set; }
        public List<ProductionItem> ProductionItem { get; set; } = new List<ProductionItem>();
    }
}
