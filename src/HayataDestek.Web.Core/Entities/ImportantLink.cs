using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayataDestek.Web.Entities
{
    [Table("ImportantLinks")]
    public class ImportantLink : FullAuditedEntity
    {
        public const int NameLength = 120;
        public const int LinkLength = 250;

        [Required]
        [StringLength(NameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(LinkLength)]
        public string Link { get; set; }

        [Required]
        public string Sort { get; set; }
    }
}
