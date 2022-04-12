using Abp.AutoMapper;
using Arq.PortalDemo.Sessions.Dto;

namespace Arq.PortalDemo.Models.Common
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput)),
     AutoMapTo(typeof(GetCurrentLoginInformationsOutput))]
    public class CurrentLoginInformationPersistanceModel
    {
        public UserLoginInfoPersistanceModel User { get; set; }

        public TenantLoginInfoPersistanceModel Tenant { get; set; }

        public ApplicationInfoPersistanceModel Application { get; set; }
    }
}