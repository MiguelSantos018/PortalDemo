using Abp.AutoMapper;
using Arq.PortalDemo.Authorization.Users;
using Arq.PortalDemo.Authorization.Users.Dto;
using Arq.PortalDemo.Web.Areas.App.Models.Common;

namespace Arq.PortalDemo.Web.Areas.App.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; set; }
    }
}