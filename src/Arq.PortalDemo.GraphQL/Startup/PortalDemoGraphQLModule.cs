using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Arq.PortalDemo.Startup
{
    [DependsOn(typeof(PortalDemoCoreModule))]
    public class PortalDemoGraphQLModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PortalDemoGraphQLModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            base.PreInitialize();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}