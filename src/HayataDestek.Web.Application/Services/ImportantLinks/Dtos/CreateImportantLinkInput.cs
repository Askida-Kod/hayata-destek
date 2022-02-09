using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using HayataDestek.Web.Entities;

namespace HayataDestek.Web.Services.ImportantLinks.Dtos
{
    [AutoMapTo(typeof(ImportantLink))]
    public class CreateImportantLinkInput
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
