using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Arq.PortalDemo.EntityFrameworkCore;

namespace Arq.PortalDemo.HealthChecks
{
    public class PortalDemoDbContextHealthCheck : IHealthCheck
    {
        private readonly DatabaseCheckHelper _checkHelper;

        public PortalDemoDbContextHealthCheck(DatabaseCheckHelper checkHelper)
        {
            _checkHelper = checkHelper;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            if (_checkHelper.Exist("db"))
            {
                return Task.FromResult(HealthCheckResult.Healthy("PortalDemoDbContext connected to database."));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("PortalDemoDbContext could not connect to database"));
        }
    }
}
