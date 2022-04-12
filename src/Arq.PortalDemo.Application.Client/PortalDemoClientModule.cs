using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Arq.PortalDemo
{
    public class PortalDemoClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PortalDemoClientModule).GetAssembly());
        }
    }
}
