using System.Threading.Tasks;
using Abp.Application.Services;
using Arq.PortalDemo.Configuration.Tenants.Dto;

namespace Arq.PortalDemo.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
