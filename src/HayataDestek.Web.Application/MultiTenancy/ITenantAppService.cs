using Abp.Application.Services;
using HayataDestek.Web.MultiTenancy.Dto;

namespace HayataDestek.Web.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

