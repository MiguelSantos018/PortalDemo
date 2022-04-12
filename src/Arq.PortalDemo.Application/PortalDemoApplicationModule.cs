using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Arq.PortalDemo.Authorization;

namespace Arq.PortalDemo
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(PortalDemoApplicationSharedModule),
        typeof(PortalDemoCoreModule)
        )]
    public class PortalDemoApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PortalDemoApplicationModule).GetAssembly());
        }
    }
}