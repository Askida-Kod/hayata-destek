using Abp.AspNetCore.Mvc.ViewComponents;

namespace HayataDestek.Web.Web.Views
{
    public abstract class WebViewComponent : AbpViewComponent
    {
        protected WebViewComponent()
        {
            LocalizationSourceName = WebConsts.LocalizationSourceName;
        }
    }
}
