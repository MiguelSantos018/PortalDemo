using System.Collections.Generic;
using Arq.PortalDemo.Editions.Dto;
using Arq.PortalDemo.MultiTenancy.Payments;

namespace Arq.PortalDemo.Web.Models.Payment
{
    public class ExtendEditionViewModel
    {
        public EditionSelectDto Edition { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}