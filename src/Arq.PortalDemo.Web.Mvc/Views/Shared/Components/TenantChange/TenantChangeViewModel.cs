using Abp.AutoMapper;
using Arq.PortalDemo.Sessions.Dto;

namespace Arq.PortalDemo.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}