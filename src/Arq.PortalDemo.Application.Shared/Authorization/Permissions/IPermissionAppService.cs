using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Arq.PortalDemo.Authorization.Permissions.Dto;

namespace Arq.PortalDemo.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
