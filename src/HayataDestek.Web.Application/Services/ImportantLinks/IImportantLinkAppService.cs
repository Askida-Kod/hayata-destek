using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using HayataDestek.Web.Services.ImportantLinks.Dtos;

namespace HayataDestek.Web.Services.ImportantLinks
{
    public interface IImportantLinkAppService : IApplicationService
    {
        Task<ListResultDto<ImportantLinkDto>> List();
    }
}
