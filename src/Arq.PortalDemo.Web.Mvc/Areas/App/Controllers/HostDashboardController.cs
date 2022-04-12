using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Arq.PortalDemo.Authorization;
using Arq.PortalDemo.DashboardCustomization;
using System.Threading.Tasks;
using Arq.PortalDemo.Web.Areas.App.Startup;

namespace Arq.PortalDemo.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Host_Dashboard)]
    public class HostDashboardController : CustomizableDashboardControllerBase
    {
        public HostDashboardController(
            DashboardViewConfiguration dashboardViewConfiguration,
            IDashboardCustomizationAppService dashboardCustomizationAppService)
            : base(dashboardViewConfiguration, dashboardCustomizationAppService)
        {

        }

        public async Task<ActionResult> Index()
        {
            return await GetView(PortalDemoDashboardCustomizationConsts.DashboardNames.DefaultHostDashboard);
        }
    }
}