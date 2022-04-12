using System.Threading.Tasks;
using Abp.Application.Services;
using Arq.PortalDemo.Sessions.Dto;

namespace Arq.PortalDemo.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
