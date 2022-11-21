namespace EnterpriseManagementApp.Entities.ViewModels
{
    public class AddProductionItem
    {
        //tutaj reszte wstawic @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        public int QuantityPCS { get; set; }
        public int QuantityPallets { get; set; }
        public String? AdditionalInformation { get; set; }
        public bool ReadyToPickUp { get; set; }
    }
}
