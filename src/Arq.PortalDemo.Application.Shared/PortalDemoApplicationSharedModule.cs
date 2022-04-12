using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Arq.PortalDemo
{
    [DependsOn(typeof(PortalDemoCoreSharedModule))]
    public class PortalDemoApplicationSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PortalDemoApplicationSharedModule).GetAssembly());
        }
    }
}