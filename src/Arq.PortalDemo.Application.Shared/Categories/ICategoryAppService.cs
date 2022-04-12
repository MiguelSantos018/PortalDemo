using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Arq.PortalDemo.Categories.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Arq.PortalDemo.Categories
{
    public interface ICategoryAppService : IApplicationService
    {
        Task<PagedResultDto<CategoryDto>> GetAll(CategoriesFilter input);
        Task CreateOrEdit(CategoryDto movie);
        Task<CategoryDto> GetById(int? Id);
        Task Delete(int Id);
    }
}