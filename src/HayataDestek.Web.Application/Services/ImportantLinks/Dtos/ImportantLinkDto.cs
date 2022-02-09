using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using HayataDestek.Web.Entities;
namespace HayataDestek.Web.Services.ImportantLinks.Dtos
{
    [AutoMapFrom(typeof(ImportantLink))]
    public class ImportantLinkDto : EntityDto, IHasCreationTime
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public string Sort { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
