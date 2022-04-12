using System.Collections.Generic;
using Arq.PortalDemo.Authorization.Users.Importing.Dto;
using Arq.PortalDemo.Dto;

namespace Arq.PortalDemo.Authorization.Users.Importing
{
    public interface IInvalidUserExporter
    {
        FileDto ExportToFile(List<ImportUserDto> userListDtos);
    }
}
