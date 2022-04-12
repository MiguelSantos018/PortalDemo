using Abp.AspNetCore.Mvc.ViewComponents;

namespace Arq.PortalDemo.Web.Views
{
    public abstract class PortalDemoViewComponent : AbpViewComponent
    {
        protected PortalDemoViewComponent()
        {
            LocalizationSourceName = PortalDemoConsts.LocalizationSourceName;
        }
    }
}