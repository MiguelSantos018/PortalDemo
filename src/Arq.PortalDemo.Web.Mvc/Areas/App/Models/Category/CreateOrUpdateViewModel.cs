using Abp.AutoMapper;
using Arq.PortalDemo.Categories.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arq.PortalDemo.Web.Areas.App.Models.Category
{
    [AutoMapFrom(typeof(CategoryDto))]
    public class CreateOrUpdateViewModel : CategoryDto
    {
        public bool IsEditMode => Id.HasValue;
    }
}
