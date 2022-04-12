using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Arq.PortalDemo.Categories.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Linq.Extensions;
using Abp.Authorization;
using Arq.PortalDemo.Authorization;
using Arq.PortalDemo.Movies;
using Abp.Runtime.Session;
using System;

namespace Arq.PortalDemo.Categories
{
    [AbpAuthorize]
    public class CategoryAppService : PortalDemoAppServiceBase, ICategoryAppService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMoviesAppService _movieService;

        public CategoryAppService(IRepository<Category> categoryRepository, IMoviesAppService movieService)
        {
            this._categoryRepository = categoryRepository;
            this._movieService = movieService;
        }

        [AbpAuthorize(AppPermissions.Pages_Categories)]
        public async Task<PagedResultDto<CategoryDto>> GetAll(CategoriesFilter input)
        {
            var categories = _categoryRepository
                            .GetAll()
                            .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                            b => b.Name.ToLower().Contains(input.Filter.ToLower()));

            var totalcount = await categories.CountAsync();
            List<Category> category = await categories
            .OrderBy(input.Sorting ?? "name asc")
            .PageBy(input)
            .ToListAsync();

            return new PagedResultDto<CategoryDto>(
            totalcount,
            category
            .Select(bp =>
            {
                var dto = ObjectMapper.Map<CategoryDto>(bp);

                return dto;
            })
            .ToList());
        }

        [AbpAuthorize(
            AppPermissions.Pages_Categories_Create,
            AppPermissions.Pages_Categories_Edit
        )]
        public async Task CreateOrEdit(CategoryDto category)
        {
            if (category.Id == null)
                await Create(category);
            else
                await Update(category);
        }

        private async Task Update(CategoryDto input)
        {
            var category = await _categoryRepository.FirstOrDefaultAsync(x => x.Id == input.Id);
            ObjectMapper.Map(input, category);
        }

        private async Task Create(CategoryDto input)
        {
            var category = ObjectMapper.Map<Category>(input);
            category.CreationTime = DateTime.Now;

            await _categoryRepository.InsertAsync(category);
        }

        [AbpAuthorize(
             AppPermissions.Pages_Categories,
             AppPermissions.Pages_Categories_Edit
         )]
        public async Task<CategoryDto> GetById(int? Id)
        {
            CategoryDto category = new CategoryDto();
            if (Id != null)
                category = ObjectMapper.Map<CategoryDto>(await _categoryRepository.FirstOrDefaultAsync(x => x.Id == Id));
            return category;
        }

        [AbpAuthorize(AppPermissions.Pages_Categories_Delete)]
        public async Task Delete(int Id)
        {
            var movies = await _movieService.GetCategoryMovies(Id);
            
            if (movies?.Count != 0 && movies != null)
                foreach (var movie in movies)
                    await _movieService.Delete(movie.Id.Value);

            await _categoryRepository.DeleteAsync(Id);
        }
    }
}
