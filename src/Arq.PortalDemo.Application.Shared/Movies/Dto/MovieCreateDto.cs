using Arq.PortalDemo.Categories.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Arq.PortalDemo.Movies.Dto
{
    public class MovieCreateDto
    {
        public long? Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public List<CategoryDto> Options { get; set; }

        public string ImageToken { get; set; }
        
        public byte[] ImageContent { get; set; }

        public string ContentType { get; set; }
    }
}
