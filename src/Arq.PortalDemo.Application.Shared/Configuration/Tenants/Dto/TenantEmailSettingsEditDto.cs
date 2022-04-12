using Abp.Auditing;
using Arq.PortalDemo.Configuration.Dto;

namespace Arq.PortalDemo.Configuration.Tenants.Dto
{
    public class TenantEmailSettingsEditDto : EmailSettingsEditDto
    {
        public bool UseHostDefaultEmailSettings { get; set; }
    }
}