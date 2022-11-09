namespace EnterpriseManagementApp.Entities
{
    public class ProductionItem
    {
        public Guid Id { get; set; }
        public String Type { get; set; }
        public String Material { get; set; }
        public int Thickness { get; set; }
        public int Length { get; set; }
        public int Diameter { get; set; }
        public int QuantityPCS { get; set; }
        public int QuantityPallets { get; set; }
        public int HallNumber { get; set; }
        public int Foreman { get; set; }
        public DateTime ProductionDate { get; set; }
        public String? AdditionalInformation { get; set; }
        public bool ReadyToPickUp { get; set; }
    }
}
