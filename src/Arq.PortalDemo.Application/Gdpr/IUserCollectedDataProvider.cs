using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using Arq.PortalDemo.Dto;

namespace Arq.PortalDemo.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}
