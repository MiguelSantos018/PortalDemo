using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Arq.PortalDemo.Editions.Dto;

namespace Arq.PortalDemo.Web.Areas.App.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}