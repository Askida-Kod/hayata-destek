using System.Collections.Generic;
using HayataDestek.Web.Roles.Dto;

namespace HayataDestek.Web.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
