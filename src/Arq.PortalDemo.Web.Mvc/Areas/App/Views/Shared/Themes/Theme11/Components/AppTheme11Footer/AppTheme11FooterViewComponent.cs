using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Arq.PortalDemo.Web.Areas.App.Models.Layout;
using Arq.PortalDemo.Web.Session;
using Arq.PortalDemo.Web.Views;

namespace Arq.PortalDemo.Web.Areas.App.Views.Shared.Themes.Theme11.Components.AppTheme11Footer
{
    public class AppTheme11FooterViewComponent : PortalDemoViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppTheme11FooterViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footerModel = new FooterViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(footerModel);
        }
    }
}
