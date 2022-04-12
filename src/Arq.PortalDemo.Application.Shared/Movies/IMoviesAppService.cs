using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Arq.PortalDemo.Movies.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Arq.PortalDemo.Movies
{
    public interface IMoviesAppService : IApplicationService
    {
        Task<PagedResultDto<MovieListDto>> GetAll(GetMoviesInput input);
        Task CreateOrEdit(MovieCreateDto movie);
        Task<MovieCreateDto> GetById(long? Id);
        Task Delete(long Id);
        Task<List<MovieCreateDto>> GetCategoryMovies(int Id);
        Task<MovieCreateDto> GetImage(int Id);
    }
}
