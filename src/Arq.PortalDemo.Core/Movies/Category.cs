using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arq.PortalDemo.Movies
{
    [Table("Categories")]
    public class Category : Entity, IHasCreationTime
    {
        public DateTime CreationTime { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
    }
}
