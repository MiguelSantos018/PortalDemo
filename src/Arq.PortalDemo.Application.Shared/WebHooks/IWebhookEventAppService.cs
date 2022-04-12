using System.Threading.Tasks;
using Abp.Webhooks;

namespace Arq.PortalDemo.WebHooks
{
    public interface IWebhookEventAppService
    {
        Task<WebhookEvent> Get(string id);
    }
}
