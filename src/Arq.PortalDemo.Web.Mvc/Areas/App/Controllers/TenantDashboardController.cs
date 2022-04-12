using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Arq.PortalDemo.Authorization;
using Arq.PortalDemo.DashboardCustomization;
using System.Threading.Tasks;
using Arq.PortalDemo.Web.Areas.App.Startup;

namespace Arq.PortalDemo.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize(AppPermissions.Pages_Tenant_Dashboard)]
    public class TenantDashboardController : CustomizableDashboardControllerBase
    {
        public TenantDashboardController(DashboardViewConfiguration dashboardViewConfiguration, 
            IDashboardCustomizationAppService dashboardCustomizationAppService) 
            : base(dashboardViewConfiguration, dashboardCustomizationAppService)
        {

        }

        public async Task<ActionResult> Index()
        {
            return await GetView(PortalDemoDashboardCustomizationConsts.DashboardNames.DefaultTenantDashboard);
        }
    }
}