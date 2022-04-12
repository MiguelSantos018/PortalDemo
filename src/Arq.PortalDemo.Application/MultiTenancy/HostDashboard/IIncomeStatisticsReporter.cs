using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Arq.PortalDemo.MultiTenancy.HostDashboard.Dto;

namespace Arq.PortalDemo.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}