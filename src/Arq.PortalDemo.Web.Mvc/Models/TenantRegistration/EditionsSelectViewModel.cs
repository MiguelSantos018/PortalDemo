using Abp.AutoMapper;
using Arq.PortalDemo.MultiTenancy.Dto;

namespace Arq.PortalDemo.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(EditionsSelectOutput))]
    public class EditionsSelectViewModel : EditionsSelectOutput
    {
    }
}
