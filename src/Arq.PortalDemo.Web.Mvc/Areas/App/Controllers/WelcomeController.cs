using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Arq.PortalDemo.Web.Controllers;

namespace Arq.PortalDemo.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize]
    public class WelcomeController : PortalDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}