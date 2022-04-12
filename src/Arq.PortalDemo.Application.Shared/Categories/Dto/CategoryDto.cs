using System;
using System.Collections.Generic;
using System.Text;

namespace Arq.PortalDemo.Categories.Dto
{
    public class CategoryDto
    {
        public int? Id { get; set; }

        public DateTime CreationTime { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public bool Selected { get; set; }
    }
}
