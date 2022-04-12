using System.Threading.Tasks;
using Abp.Application.Services;
using Arq.PortalDemo.MultiTenancy.Payments.PayPal.Dto;

namespace Arq.PortalDemo.MultiTenancy.Payments.PayPal
{
    public interface IPayPalPaymentAppService : IApplicationService
    {
        Task ConfirmPayment(long paymentId, string paypalOrderId);

        PayPalConfigurationDto GetConfiguration();
    }
}
