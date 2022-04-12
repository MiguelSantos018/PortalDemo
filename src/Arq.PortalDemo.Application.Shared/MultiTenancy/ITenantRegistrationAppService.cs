using System.Threading.Tasks;
using Abp.Application.Services;
using Arq.PortalDemo.Editions.Dto;
using Arq.PortalDemo.MultiTenancy.Dto;

namespace Arq.PortalDemo.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}