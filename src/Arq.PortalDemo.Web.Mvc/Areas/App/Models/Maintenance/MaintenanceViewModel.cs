using System.Collections.Generic;
using Arq.PortalDemo.Caching.Dto;

namespace Arq.PortalDemo.Web.Areas.App.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}