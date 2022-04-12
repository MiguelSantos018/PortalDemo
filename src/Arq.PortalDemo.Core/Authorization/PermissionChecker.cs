using Abp.Authorization;
using Arq.PortalDemo.Authorization.Roles;
using Arq.PortalDemo.Authorization.Users;

namespace Arq.PortalDemo.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
