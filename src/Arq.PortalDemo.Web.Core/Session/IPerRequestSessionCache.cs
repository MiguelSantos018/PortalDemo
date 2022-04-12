using System.Threading.Tasks;
using Arq.PortalDemo.Sessions.Dto;

namespace Arq.PortalDemo.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
