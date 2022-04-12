using System.Collections.Generic;
using Arq.PortalDemo.Authorization.Users.Dto;
using Arq.PortalDemo.Dto;

namespace Arq.PortalDemo.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}