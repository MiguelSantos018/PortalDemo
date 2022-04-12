using Microsoft.Extensions.Configuration;

namespace Arq.PortalDemo.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
