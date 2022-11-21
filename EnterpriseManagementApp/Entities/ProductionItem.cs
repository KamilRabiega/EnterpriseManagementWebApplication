namespace EnterpriseManagementApp.Entities
{
    public class ProductionItem
    {
        public Guid Id { get; set; }
            public Type Type { get; set; }
            public int TypeId { get; set; }
            public Material Material { get; set; }
            public int MaterialId { get; set; }
        public int QuantityPCS { get; set; }
        public int QuantityPallets { get; set; }
            public Hall Hall { get; set; }
            public int HallId { get; set; }
            public Foreman Foreman { get; set; }
            public int ForemanId { get; set; }
        public DateTime ProductionDate { get; set; }
        public String? AdditionalInformation { get; set; }
        public bool ReadyToPickUp { get; set; }
    }
}
