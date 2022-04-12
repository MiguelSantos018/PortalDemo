using Abp.Domain.Services;

namespace Arq.PortalDemo
{
    public abstract class PortalDemoDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected PortalDemoDomainServiceBase()
        {
            LocalizationSourceName = PortalDemoConsts.LocalizationSourceName;
        }
    }
}
