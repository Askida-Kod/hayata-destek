using Abp.AutoMapper;
using HayataDestek.Web.Roles.Dto;
using HayataDestek.Web.Web.Models.Common;

namespace HayataDestek.Web.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
