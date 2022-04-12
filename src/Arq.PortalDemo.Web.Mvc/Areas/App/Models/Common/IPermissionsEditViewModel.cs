using System.Collections.Generic;
using Arq.PortalDemo.Authorization.Permissions.Dto;

namespace Arq.PortalDemo.Web.Areas.App.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}