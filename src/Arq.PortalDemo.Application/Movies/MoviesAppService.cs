using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Arq.PortalDemo.Movies.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Abp.Linq.Extensions;
using Abp.Runtime.Session;
using Abp.Authorization;
using Arq.PortalDemo.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Arq.PortalDemo.Categories.Dto;
using Arq.PortalDemo.Storage;
using Abp.UI;
using Abp.Domain.Uow;

namespace Arq.PortalDemo.Movies
{
    [AbpAuthorize]
    public class MoviesAppService : PortalDemoAppServiceBase, IMoviesAppService
    {
        private readonly IRepository<Movie, long> _movieRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly ITempFileCacheManager _tempFileCacheManager;
        private readonly IBinaryObjectManager _binaryObjectManager;

        public MoviesAppService
            (IRepository<Movie, long> movieRepository,
            IRepository<Category> categoryRepository,
            ITempFileCacheManager tempFileCacheManager,
            IBinaryObjectManager binaryObjectManager)
        {
            _movieRepository = movieRepository;
            _categoryRepository = categoryRepository;
            _tempFileCacheManager = tempFileCacheManager;
            _binaryObjectManager = binaryObjectManager;
        }

        [AbpAuthorize(Authorization.AppPermissions.Pages_Movies)]
        public async Task<PagedResultDto<MovieListDto>> GetAll(GetMoviesInput input)
        {
            var userId = AbpSession.GetUserId();
            var movies = _movieRepository
                            .GetAll()
                            .Include(i => i.Category)
                            .WhereIf(userId != 0,
                            x => x.UserId == userId)
                            .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                            b => b.Description.ToLower().Contains(input.Filter.ToLower())
                            || b.Title.ToLower().Contains(input.Filter.ToLower()))
                            .WhereIf(!string.IsNullOrWhiteSpace(input.Description),
                            b => b.Description.ToLower().Contains(input.Description.ToLower()))
                            .WhereIf(!string.IsNullOrWhiteSpace(input.Title),
                            b => b.Title.ToLower().Contains(input.Title.ToLower()));

            var totalcount = await movies.CountAsync();
            List<Movie> movie = await movies
            .OrderBy(input.Sorting ?? "title asc")
            .PageBy(input)
            .ToListAsync();

            return new PagedResultDto<MovieListDto>(
            totalcount,
            movie
            .Select(bp =>
            {
                var dto = ObjectMapper.Map<MovieListDto>(bp);
                dto.CategoryName = bp.Category?.Name;

                return dto;
            })
            .ToList());
        }

        [AbpAuthorize(
            AppPermissions.Pages_Movies_Create,
            AppPermissions.Pages_Movies_Edit
        )]
        public async Task CreateOrEdit(MovieCreateDto movie)
        {
            if (movie.Id == null)
                await Create(movie);
            else
                await Update(movie);
        }

        private async Task Create(MovieCreateDto input)
        {
            var movie = ObjectMapper.Map<Movie>(input);
            movie.UserId = AbpSession.GetUserId();
            movie.CreationTime = DateTime.Now;

            if (!string.IsNullOrEmpty(input.ImageToken))
            {
                var imageBytes = _tempFileCacheManager.GetFileInfo(input.ImageToken);

                if (imageBytes == null)
                {
                    throw new UserFriendlyException("There is no such image file with the token: " + input.ImageToken);
                }

                var storedFile = new BinaryObject(AbpSession.TenantId, imageBytes.File, $"Carousel picture {AbpSession.UserId}. {DateTime.UtcNow}");
                await _binaryObjectManager.SaveAsync(storedFile);

                movie.ImageId = storedFile.Id;
                movie.ImageContentType = imageBytes.FileType;
            }

            await _movieRepository.InsertAsync(movie);
        }

        private async Task Update(MovieCreateDto input)
        {
            var movie = await _movieRepository.FirstOrDefaultAsync(x => x.Id == input.Id);
            var imageId = movie.ImageId;
            ObjectMapper.Map(input, movie);
            movie.UserId = AbpSession.GetUserId();

            if (!string.IsNullOrEmpty(input.ImageToken))
            {
                await _binaryObjectManager.DeleteAsync(movie.ImageId);

                var imageBytes = _tempFileCacheManager.GetFileInfo(input.ImageToken);

                if (imageBytes == null)
                {
                    throw new UserFriendlyException("There is no such image file with the token: " + input.ImageToken);
                }

                var storedFile = new BinaryObject(AbpSession.TenantId, imageBytes.File, $"Carousel picture {AbpSession.UserId}. {DateTime.UtcNow}");
                await _binaryObjectManager.SaveAsync(storedFile);

                movie.ImageId = storedFile.Id;
                movie.ImageContentType = imageBytes.FileType;
            }
            else
                movie.ImageId = imageId;
        }

        [AbpAuthorize(
            AppPermissions.Pages_Movies,
            AppPermissions.Pages_Movies_Edit
        )]
        public async Task<MovieCreateDto> GetById(long? Id)
        {
            MovieCreateDto movie = new MovieCreateDto();
            if (Id != null)
                movie = ObjectMapper.Map<MovieCreateDto>(await _movieRepository.FirstOrDefaultAsync(x => x.Id == Id));

            movie.Options = GetCategories(movie.CategoryId);

            return movie;
        }

        [AbpAuthorize(AppPermissions.Pages_Movies_Delete)]
        public async Task Delete(long Id)
        {
            await _movieRepository.DeleteAsync(Id);
        }

        [AbpAuthorize(AppPermissions.Pages_Categories_Delete)]
        public async Task<List<MovieCreateDto>> GetCategoryMovies(int Id)
        {
            return await _movieRepository.GetAll().Where(w => w.CategoryId == Id).Select(s => new MovieCreateDto() { Id = s.Id }).ToListAsync();
        }

        public async Task<byte[]> GetImageByIdOrNull(Guid profilePictureId)
        {
            var file = await _binaryObjectManager.GetOrNullAsync(profilePictureId);
            if (file == null)
            {
                return null;
            }

            return file.Bytes;
        }

        public async Task<MovieCreateDto> GetImage(int Id)
        {
            var img = await _movieRepository
            .FirstOrDefaultAsync(x => x.Id == Id);

            MovieCreateDto input = new MovieCreateDto();
            if (img != null)
            {
                var bytes = await GetImageByIdOrNull(img.ImageId);

                if (bytes != null)
                {
                    input = new MovieCreateDto()
                    {
                        ImageContent = bytes,
                        ContentType = img.ImageContentType,
                    };
                    return input;
                }
            }
            return input;
        }

        private List<CategoryDto> GetCategories(int? categoryId = null)
        {
            var categories = _categoryRepository
                .GetAll()
                .Select(s => new CategoryDto()
                {
                    Name = s.Name,
                    Id = s.Id,
                    Selected = s.Id == categoryId
                })
                .ToList();
            return categories;
        }
    }
}
