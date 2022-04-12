using System;
using Arq.PortalDemo.Core;
using Arq.PortalDemo.Core.Dependency;
using Arq.PortalDemo.Services.Permission;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Arq.PortalDemo.Extensions.MarkupExtensions
{
    [ContentProperty("Text")]
    public class HasPermissionExtension : IMarkupExtension
    {
        public string Text { get; set; }
        
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ApplicationBootstrapper.AbpBootstrapper == null || Text == null)
            {
                return false;
            }

            var permissionService = DependencyResolver.Resolve<IPermissionService>();
            return permissionService.HasPermission(Text);
        }
    }
}