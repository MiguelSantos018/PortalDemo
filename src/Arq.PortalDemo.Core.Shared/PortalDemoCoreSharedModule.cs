using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Arq.PortalDemo
{
    public class PortalDemoCoreSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PortalDemoCoreSharedModule).GetAssembly());
        }
    }
}