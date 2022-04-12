using System.Collections.Generic;
using Arq.PortalDemo.Organizations.Dto;

namespace Arq.PortalDemo.Web.Areas.App.Models.Common
{
    public interface IOrganizationUnitsEditViewModel
    {
        List<OrganizationUnitDto> AllOrganizationUnits { get; set; }

        List<string> MemberedOrganizationUnits { get; set; }
    }
}