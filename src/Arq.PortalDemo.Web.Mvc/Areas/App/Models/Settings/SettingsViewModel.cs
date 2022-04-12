using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Arq.PortalDemo.Configuration.Tenants.Dto;

namespace Arq.PortalDemo.Web.Areas.App.Models.Settings
{
    public class SettingsViewModel
    {
        public TenantSettingsEditDto Settings { get; set; }
        
        public List<ComboboxItemDto> TimezoneItems { get; set; }
        
        public List<string> EnabledSocialLoginSettings { get; set; } = new List<string>();
    }
}