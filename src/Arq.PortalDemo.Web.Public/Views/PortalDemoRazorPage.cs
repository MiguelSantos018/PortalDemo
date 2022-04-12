using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Arq.PortalDemo.Web.Public.Views
{
    public abstract class PortalDemoRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected PortalDemoRazorPage()
        {
            LocalizationSourceName = PortalDemoConsts.LocalizationSourceName;
        }
    }
}
