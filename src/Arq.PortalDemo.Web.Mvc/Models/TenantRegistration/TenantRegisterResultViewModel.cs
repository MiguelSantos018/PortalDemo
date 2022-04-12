using Abp.AutoMapper;
using Arq.PortalDemo.MultiTenancy.Dto;

namespace Arq.PortalDemo.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(RegisterTenantOutput))]
    public class TenantRegisterResultViewModel : RegisterTenantOutput
    {
        public string TenantLoginAddress { get; set; }
    }
}