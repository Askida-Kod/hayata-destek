using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HayataDestek.Web.Services.ImportantLinks;
using HayataDestek.Web.Web.Models.ImportantLinks;

namespace HayataDestek.Web.Web.Controllers
{
    public class ImportantLinksController : HayataDestekWebControllerBase
    {
        private readonly IImportantLinkAppService _importantLinkAppService;

        public ImportantLinksController(IImportantLinkAppService importantLinkAppService)
        {
            _importantLinkAppService = importantLinkAppService;
        }

        public async Task<ActionResult> Index()
        {
            var data = (await _importantLinkAppService.List()).Items;
            var model = new IndexViewModel(data);
            return View(model);
        }
    }
}
