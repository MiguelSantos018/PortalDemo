using Abp.Application.Services;
using Arq.PortalDemo.Dto;
using Arq.PortalDemo.Logging.Dto;

namespace Arq.PortalDemo.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
