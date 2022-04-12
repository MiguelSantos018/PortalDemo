using Abp.AspNetCore.Mvc.ViewComponents;

namespace Arq.PortalDemo.Web.Public.Views
{
    public abstract class PortalDemoViewComponent : AbpViewComponent
    {
        protected PortalDemoViewComponent()
        {
            LocalizationSourceName = PortalDemoConsts.LocalizationSourceName;
        }
    }
}