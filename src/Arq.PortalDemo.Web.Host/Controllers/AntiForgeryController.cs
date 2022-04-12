using Microsoft.AspNetCore.Antiforgery;

namespace Arq.PortalDemo.Web.Controllers
{
    public class AntiForgeryController : PortalDemoControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
