using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Arq.PortalDemo.Web.Areas.App.Models.Layout;
using Arq.PortalDemo.Web.Session;
using Arq.PortalDemo.Web.Views;

namespace Arq.PortalDemo.Web.Areas.App.Views.Shared.Themes.Theme10.Components.AppTheme10Brand
{
    public class AppTheme10BrandViewComponent : PortalDemoViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppTheme10BrandViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var headerModel = new HeaderViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(headerModel);
        }
    }
}
