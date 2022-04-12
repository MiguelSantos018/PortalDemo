using System.Collections.Generic;
using Arq.PortalDemo.Authorization.Users.Importing.Dto;
using Abp.Dependency;

namespace Arq.PortalDemo.Authorization.Users.Importing
{
    public interface IUserListExcelDataReader: ITransientDependency
    {
        List<ImportUserDto> GetUsersFromExcel(byte[] fileBytes);
    }
}
