using System.Threading.Tasks;
using Abp.Application.Services;
using Arq.PortalDemo.Install.Dto;

namespace Arq.PortalDemo.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}