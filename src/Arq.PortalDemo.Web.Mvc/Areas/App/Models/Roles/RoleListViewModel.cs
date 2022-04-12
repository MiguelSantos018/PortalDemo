using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Arq.PortalDemo.Authorization.Permissions.Dto;
using Arq.PortalDemo.Web.Areas.App.Models.Common;

namespace Arq.PortalDemo.Web.Areas.App.Models.Roles
{
    public class RoleListViewModel : IPermissionsEditViewModel
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}