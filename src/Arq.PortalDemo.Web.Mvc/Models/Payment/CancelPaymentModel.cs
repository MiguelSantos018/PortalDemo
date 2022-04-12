using Arq.PortalDemo.MultiTenancy.Payments;

namespace Arq.PortalDemo.Web.Models.Payment
{
    public class CancelPaymentModel
    {
        public string PaymentId { get; set; }

        public SubscriptionPaymentGatewayType Gateway { get; set; }
    }
}