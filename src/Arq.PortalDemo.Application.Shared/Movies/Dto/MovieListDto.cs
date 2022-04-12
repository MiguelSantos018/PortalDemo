using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arq.PortalDemo.Movies.Dto
{
    public class MovieListDto
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }
    }

    public class GetMoviesInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}