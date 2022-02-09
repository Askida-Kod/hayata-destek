using Abp.Authorization;
using HayataDestek.Web.Authorization.Roles;
using HayataDestek.Web.Authorization.Users;

namespace HayataDestek.Web.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
