using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Arq.PortalDemo.Configure;
using Arq.PortalDemo.Startup;
using Arq.PortalDemo.Test.Base;

namespace Arq.PortalDemo.GraphQL.Tests
{
    [DependsOn(
        typeof(PortalDemoGraphQLModule),
        typeof(PortalDemoTestBaseModule))]
    public class PortalDemoGraphQLTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddAndConfigureGraphQL();

            WindsorRegistrationHelper.CreateServiceProvider(IocManager.IocContainer, services);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PortalDemoGraphQLTestModule).GetAssembly());
        }
    }
}