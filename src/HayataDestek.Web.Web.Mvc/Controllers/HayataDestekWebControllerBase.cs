using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;

namespace HayataDestek.Web.Web.Controllers
{
    public class HayataDestekWebControllerBase : AbpController
    {
        public HayataDestekWebControllerBase() => LocalizationSourceName = WebConsts.LocalizationSourceName;
    }
}
