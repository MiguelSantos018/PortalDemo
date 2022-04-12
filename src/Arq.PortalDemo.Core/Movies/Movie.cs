using Abp;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arq.PortalDemo.Movies
{
    [Table("Movies")]
    public class Movie : Entity<long>, IHasCreationTime, IMayHaveTenant
    {
        public long UserId { get; set; }

        public int? TenantId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationTime { get; set; }

        public int CategoryId { get; set; }
        public Guid ImageId { get; set; }
        public string ImageContentType { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }
    }
}
