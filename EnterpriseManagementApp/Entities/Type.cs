namespace EnterpriseManagementApp.Entities
{
    public class Type
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Diameter { get; set; }
        public int Length { get; set; }
        public int WallThickness { get; set; }
        public String Class { get; set; }
        public List<ProductionItem> ProductionItem { get; set; } = new List<ProductionItem>();
    }
}
