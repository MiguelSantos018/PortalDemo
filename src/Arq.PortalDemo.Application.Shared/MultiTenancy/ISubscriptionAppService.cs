using System.Threading.Tasks;
using Abp.Application.Services;

namespace Arq.PortalDemo.MultiTenancy
{
    public interface ISubscriptionAppService : IApplicationService
    {
        Task DisableRecurringPayments();

        Task EnableRecurringPayments();
    }
}
