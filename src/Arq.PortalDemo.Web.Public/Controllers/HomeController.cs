using Microsoft.AspNetCore.Mvc;
using Arq.PortalDemo.Web.Controllers;

namespace Arq.PortalDemo.Web.Public.Controllers
{
    public class HomeController : PortalDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}