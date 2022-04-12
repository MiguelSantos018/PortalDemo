using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace Arq.PortalDemo.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}
