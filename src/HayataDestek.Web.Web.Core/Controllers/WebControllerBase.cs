using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace HayataDestek.Web.Controllers
{
    public abstract class WebControllerBase: AbpController
    {
        protected WebControllerBase()
        {
            LocalizationSourceName = WebConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
