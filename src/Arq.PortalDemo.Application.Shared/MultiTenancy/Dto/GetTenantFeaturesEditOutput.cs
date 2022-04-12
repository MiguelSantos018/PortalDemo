using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Arq.PortalDemo.Editions.Dto;

namespace Arq.PortalDemo.MultiTenancy.Dto
{
    public class GetTenantFeaturesEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}