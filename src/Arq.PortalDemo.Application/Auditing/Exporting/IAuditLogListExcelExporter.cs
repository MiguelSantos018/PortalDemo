using System.Collections.Generic;
using Arq.PortalDemo.Auditing.Dto;
using Arq.PortalDemo.Dto;

namespace Arq.PortalDemo.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}
