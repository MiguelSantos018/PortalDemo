using Abp.AspNetCore.Mvc.Authorization;
using Arq.PortalDemo.Authorization;
using Arq.PortalDemo.Storage;
using Abp.BackgroundJobs;
using Abp.Authorization;

namespace Arq.PortalDemo.Web.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Users)]
    public class UsersController : UsersControllerBase
    {
        public UsersController(IBinaryObjectManager binaryObjectManager, IBackgroundJobManager backgroundJobManager)
            : base(binaryObjectManager, backgroundJobManager)
        {
        }
    }
}