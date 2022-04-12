using Abp.AutoMapper;
using Arq.PortalDemo.Movies.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arq.PortalDemo.Web.Areas.App.Models.Movies
{
    [AutoMapFrom(typeof(MovieCreateDto))]
    public class MovieViewModel : MovieCreateDto
    {
    }
}
