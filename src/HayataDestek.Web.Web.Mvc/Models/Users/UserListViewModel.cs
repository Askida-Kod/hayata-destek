using System.Collections.Generic;
using HayataDestek.Web.Roles.Dto;

namespace HayataDestek.Web.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
