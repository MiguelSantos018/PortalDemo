using Abp.Application.Services.Dto;

namespace Arq.PortalDemo.Authorization.Users.Dto
{
    public interface IGetLoginAttemptsInput: ISortedResultRequest
    {
        string Filter { get; set; }
    }
}