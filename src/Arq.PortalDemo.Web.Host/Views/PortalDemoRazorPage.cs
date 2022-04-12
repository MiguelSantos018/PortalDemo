using Abp.AspNetCore.Mvc.Views;

namespace Arq.PortalDemo.Web.Views
{
    public abstract class PortalDemoRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected PortalDemoRazorPage()
        {
            LocalizationSourceName = PortalDemoConsts.LocalizationSourceName;
        }
    }
}
