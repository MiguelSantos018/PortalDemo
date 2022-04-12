using System.Collections.Generic;
using Abp;
using Arq.PortalDemo.Chat.Dto;
using Arq.PortalDemo.Dto;

namespace Arq.PortalDemo.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(UserIdentifier user, List<ChatMessageExportDto> messages);
    }
}
