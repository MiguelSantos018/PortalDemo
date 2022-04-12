using System.Collections.Generic;
using Abp.Localization;
using Arq.PortalDemo.Install.Dto;

namespace Arq.PortalDemo.Web.Models.Install
{
    public class InstallViewModel
    {
        public List<ApplicationLanguage> Languages { get; set; }

        public AppSettingsJsonDto AppSettingsJson { get; set; }
    }
}
