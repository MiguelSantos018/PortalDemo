﻿using System.Collections.Generic;
using Arq.PortalDemo.DashboardCustomization.Dto;

namespace Arq.PortalDemo.Web.Areas.App.Models.CustomizableDashboard
{
    public class AddWidgetViewModel
    {
        public List<WidgetOutput> Widgets { get; set; }

        public string DashboardName { get; set; }

        public string PageId { get; set; }
    }
}