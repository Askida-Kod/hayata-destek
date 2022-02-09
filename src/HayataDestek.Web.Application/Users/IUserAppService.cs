using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using HayataDestek.Web.Roles.Dto;
using HayataDestek.Web.Users.Dto;

namespace HayataDestek.Web.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task DeActivate(EntityDto<long> user);
        Task Activate(EntityDto<long> user);
        Task<ListResultDto<RoleDto>> GetRoles();
        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}
