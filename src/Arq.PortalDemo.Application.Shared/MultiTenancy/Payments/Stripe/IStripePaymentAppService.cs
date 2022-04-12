using System.Threading.Tasks;
using Abp.Application.Services;
using Arq.PortalDemo.MultiTenancy.Payments.Dto;
using Arq.PortalDemo.MultiTenancy.Payments.Stripe.Dto;

namespace Arq.PortalDemo.MultiTenancy.Payments.Stripe
{
    public interface IStripePaymentAppService : IApplicationService
    {
        Task ConfirmPayment(StripeConfirmPaymentInput input);

        StripeConfigurationDto GetConfiguration();

        Task<SubscriptionPaymentDto> GetPaymentAsync(StripeGetPaymentInput input);

        Task<string> CreatePaymentSession(StripeCreatePaymentSessionInput input);
    }
}