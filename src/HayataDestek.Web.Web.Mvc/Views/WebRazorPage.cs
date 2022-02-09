using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace HayataDestek.Web.Web.Views
{
    public abstract class WebRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected WebRazorPage()
        {
            LocalizationSourceName = WebConsts.LocalizationSourceName;
        }
    }
}
