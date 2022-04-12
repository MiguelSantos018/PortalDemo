using System.Collections.Generic;
using Arq.PortalDemo.Editions.Dto;

namespace Arq.PortalDemo.Web.Areas.App.Models.Tenants
{
    public class TenantIndexViewModel
    {
        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }
    }
}