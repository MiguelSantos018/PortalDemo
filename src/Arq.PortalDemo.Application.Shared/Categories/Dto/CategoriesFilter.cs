using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arq.PortalDemo.Categories.Dto
{
    public class CategoriesFilter : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
