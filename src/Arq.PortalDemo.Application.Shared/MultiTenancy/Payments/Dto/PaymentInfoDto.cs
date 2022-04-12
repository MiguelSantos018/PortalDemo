using Arq.PortalDemo.Editions.Dto;

namespace Arq.PortalDemo.MultiTenancy.Payments.Dto
{
    public class PaymentInfoDto
    {
        public EditionSelectDto Edition { get; set; }

        public decimal AdditionalPrice { get; set; }

        public bool IsLessThanMinimumUpgradePaymentAmount()
        {
            return AdditionalPrice < PortalDemoConsts.MinimumUpgradePaymentAmount;
        }
    }
}
