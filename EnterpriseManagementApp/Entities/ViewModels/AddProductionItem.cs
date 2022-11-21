namespace EnterpriseManagementApp.Entities.ViewModels
{
    public class AddProductionItem
    {
        public int TypeId { get; set; }
        public int MaterialId { get; set; }
        public int QuantityPCS { get; set; }
        public int QuantityPallets { get; set; }
        public int HallId { get; set; }
        public int ForemanId { get; set; }
        public String? AdditionalInformation { get; set; }
        public bool ReadyToPickUp { get; set; }
    }
}
