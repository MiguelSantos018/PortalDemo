using System.Collections.Generic;
using Arq.PortalDemo.Authorization.Permissions.Dto;

namespace Arq.PortalDemo.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}