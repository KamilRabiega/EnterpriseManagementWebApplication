using EnterpriseManagementApp.Enums;

namespace EnterpriseManagementApp.Entities.ViewModels
{
    public class Notification
    {
        public string Message { get; set; }
        public NotificationType Type { get; set; }
    }
}
