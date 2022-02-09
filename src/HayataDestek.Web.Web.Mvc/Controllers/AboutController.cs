using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using HayataDestek.Web.Controllers;

namespace HayataDestek.Web.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : WebControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
