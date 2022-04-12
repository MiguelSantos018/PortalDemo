using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Arq.PortalDemo.Sessions.Dto;

namespace Arq.PortalDemo.Models.Common
{
    [AutoMapFrom(typeof(TenantLoginInfoDto)),
     AutoMapTo(typeof(TenantLoginInfoDto))]
    public class TenantLoginInfoPersistanceModel : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}