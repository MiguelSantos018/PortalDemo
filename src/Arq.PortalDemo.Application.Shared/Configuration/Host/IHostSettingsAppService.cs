using System.Threading.Tasks;
using Abp.Application.Services;
using Arq.PortalDemo.Configuration.Host.Dto;

namespace Arq.PortalDemo.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
