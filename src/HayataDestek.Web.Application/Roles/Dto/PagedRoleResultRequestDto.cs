using Abp.Application.Services.Dto;

namespace HayataDestek.Web.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

