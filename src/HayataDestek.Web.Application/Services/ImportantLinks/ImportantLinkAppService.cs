using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using AutoMapper;
using HayataDestek.Web.Authorization.Users;
using HayataDestek.Web.Entities;
using HayataDestek.Web.Services.ImportantLinks.Dtos;
using HayataDestek.Web.Users.Dto;
using Microsoft.EntityFrameworkCore;

namespace HayataDestek.Web.Services.ImportantLinks
{
    /// <inheritdoc />
    public class ImportantLinkAppService :  AsyncCrudAppService<ImportantLink, ImportantLinkDto, int, PagedImportantLinkResultRequestDto, ImportantLinkDto, ImportantLinkDto> ,IImportantLinkAppService
    {
        private readonly IRepository<ImportantLink> _importantLinkRepository;

        /// <inheritdoc />
        public ImportantLinkAppService(IRepository<ImportantLink> importantLinkRepository) : base(importantLinkRepository)
        {
            _importantLinkRepository = importantLinkRepository;
        }

        /// <inheritdoc />
        public async Task<ListResultDto<ImportantLinkDto>> List()
        {
            var result = await _importantLinkRepository
                .GetAll()
                .Where(x => !x.IsDeleted)
                .OrderByDescending(t => t.CreationTime)
                .ToListAsync();
       

            return new ListResultDto<ImportantLinkDto>(
                    ObjectMapper.Map<List<ImportantLinkDto>>(result)
            );
        }
    }
}
