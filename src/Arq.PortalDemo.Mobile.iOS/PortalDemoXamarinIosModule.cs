using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Arq.PortalDemo
{
    [DependsOn(typeof(PortalDemoXamarinSharedModule))]
    public class PortalDemoXamarinIosModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PortalDemoXamarinIosModule).GetAssembly());
        }
    }
}