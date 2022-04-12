using System.Collections.Generic;
using Arq.PortalDemo.Editions.Dto;
using Arq.PortalDemo.MultiTenancy.Payments;

namespace Arq.PortalDemo.Web.Models.Payment
{
    public class UpgradeEditionViewModel
    {
        public EditionSelectDto Edition { get; set; }

        public PaymentPeriodType PaymentPeriodType { get; set; }

        public SubscriptionPaymentType SubscriptionPaymentType { get; set; }

        public decimal? AdditionalPrice { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}