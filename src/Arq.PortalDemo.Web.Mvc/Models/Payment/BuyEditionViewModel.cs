using System.Collections.Generic;
using Arq.PortalDemo.Editions;
using Arq.PortalDemo.Editions.Dto;
using Arq.PortalDemo.MultiTenancy.Payments;
using Arq.PortalDemo.MultiTenancy.Payments.Dto;

namespace Arq.PortalDemo.Web.Models.Payment
{
    public class BuyEditionViewModel
    {
        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public decimal? AdditionalPrice { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}
