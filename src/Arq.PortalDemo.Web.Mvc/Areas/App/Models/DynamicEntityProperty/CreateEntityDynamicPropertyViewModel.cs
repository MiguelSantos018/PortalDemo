using System.Collections.Generic;
using Arq.PortalDemo.DynamicEntityProperties.Dto;

namespace Arq.PortalDemo.Web.Areas.App.Models.DynamicEntityProperty
{
    public class CreateEntityDynamicPropertyViewModel
    {
        public string EntityFullName { get; set; }

        public List<string> AllEntities { get; set; }

        public List<DynamicPropertyDto> DynamicProperties { get; set; }
    }
}
