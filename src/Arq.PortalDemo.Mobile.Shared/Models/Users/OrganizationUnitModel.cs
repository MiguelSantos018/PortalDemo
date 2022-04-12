using Abp.AutoMapper;
using Arq.PortalDemo.Organizations.Dto;

namespace Arq.PortalDemo.Models.Users
{
    [AutoMapFrom(typeof(OrganizationUnitDto))]
    public class OrganizationUnitModel : OrganizationUnitDto
    {
        public bool IsAssigned { get; set; }
    }
}