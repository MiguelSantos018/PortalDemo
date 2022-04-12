using System.Threading.Tasks;
using Arq.PortalDemo.Authorization.Users;

namespace Arq.PortalDemo.WebHooks
{
    public interface IAppWebhookPublisher
    {
        Task PublishTestWebhook();
    }
}
