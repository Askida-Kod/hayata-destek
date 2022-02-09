using System.Collections.Generic;
using HayataDestek.Web.Roles.Dto;

namespace HayataDestek.Web.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}