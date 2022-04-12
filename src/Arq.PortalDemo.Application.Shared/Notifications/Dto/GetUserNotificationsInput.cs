using System;
using Abp.Notifications;
using Arq.PortalDemo.Dto;

namespace Arq.PortalDemo.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}