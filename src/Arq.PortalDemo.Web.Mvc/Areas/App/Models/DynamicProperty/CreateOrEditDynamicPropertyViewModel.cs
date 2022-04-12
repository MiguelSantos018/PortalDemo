using System.Collections.Generic;
using Arq.PortalDemo.DynamicEntityProperties.Dto;

namespace Arq.PortalDemo.Web.Areas.App.Models.DynamicProperty
{
    public class CreateOrEditDynamicPropertyViewModel
    {
        public DynamicPropertyDto DynamicPropertyDto { get; set; }

        public List<string> AllowedInputTypes { get; set; }
    }
}
