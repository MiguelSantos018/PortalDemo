using Microsoft.Extensions.DependencyInjection;
using Arq.PortalDemo.HealthChecks;

namespace Arq.PortalDemo.Web.HealthCheck
{
    public static class AbpZeroHealthCheck
    {
        public static IHealthChecksBuilder AddAbpZeroHealthCheck(this IServiceCollection services)
        {
            var builder = services.AddHealthChecks();
            builder.AddCheck<PortalDemoDbContextHealthCheck>("Database Connection");
            builder.AddCheck<PortalDemoDbContextUsersHealthCheck>("Database Connection with user check");
            builder.AddCheck<CacheHealthCheck>("Cache");

            // add your custom health checks here
            // builder.AddCheck<MyCustomHealthCheck>("my health check");

            return builder;
        }
    }
}
