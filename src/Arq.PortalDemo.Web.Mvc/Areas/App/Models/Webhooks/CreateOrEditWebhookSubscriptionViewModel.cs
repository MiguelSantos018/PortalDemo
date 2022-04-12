﻿using Abp.Application.Services.Dto;
using Abp.Webhooks;
using Arq.PortalDemo.WebHooks.Dto;

namespace Arq.PortalDemo.Web.Areas.App.Models.Webhooks
{
    public class CreateOrEditWebhookSubscriptionViewModel
    {
        public WebhookSubscription WebhookSubscription { get; set; }

        public ListResultDto<GetAllAvailableWebhooksOutput> AvailableWebhookEvents { get; set; }
    }
}
