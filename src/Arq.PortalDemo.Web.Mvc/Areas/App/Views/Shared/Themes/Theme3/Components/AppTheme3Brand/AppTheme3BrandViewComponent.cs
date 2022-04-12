using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Arq.PortalDemo.Web.Areas.App.Models.Layout;
using Arq.PortalDemo.Web.Session;
using Arq.PortalDemo.Web.Views;

namespace Arq.PortalDemo.Web.Areas.App.Views.Shared.Themes.Theme3.Components.AppTheme3Brand
{
    public class AppTheme3BrandViewComponent : PortalDemoViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppTheme3BrandViewComponent(IPerRequestSessionCache sessionCache)
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
