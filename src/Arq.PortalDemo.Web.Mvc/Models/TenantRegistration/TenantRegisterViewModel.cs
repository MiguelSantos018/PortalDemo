using Arq.PortalDemo.Editions;
using Arq.PortalDemo.Editions.Dto;
using Arq.PortalDemo.MultiTenancy.Payments;
using Arq.PortalDemo.Security;
using Arq.PortalDemo.MultiTenancy.Payments.Dto;

namespace Arq.PortalDemo.Web.Models.TenantRegistration
{
    public class TenantRegisterViewModel
    {
        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }

        public int? EditionId { get; set; }

        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }
    }
}
